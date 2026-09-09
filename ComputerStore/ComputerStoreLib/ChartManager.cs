using ComputerStoreLib.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ComputerStoreLib
{
    /// <summary>
    /// Управление графиками на форме
    /// </summary>
    public class ChartManager
    {
        private readonly PgComputerStoreLoader loader_;
        private readonly LiveCharts.WinForms.CartesianChart cartesianChart_;
        private readonly LiveCharts.WinForms.PieChart pieChart_;

        // Единственный конструктор
        public ChartManager(
            PgComputerStoreLoader loader,
            LiveCharts.WinForms.CartesianChart cartesianChart,
            LiveCharts.WinForms.PieChart pieChart)
        {
            loader_ = loader;
            cartesianChart_ = cartesianChart;
            pieChart_ = pieChart;
        }

        /// <summary>
        /// Начальная настройка графиков
        /// </summary>
        public void ConfigureCharts()
        {
            // Проверяем, что графики инициализированы
            if (cartesianChart_ == null)
            {
                System.Windows.Forms.MessageBox.Show("CartesianChart не инициализирован!", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            if (pieChart_ == null)
            {
                System.Windows.Forms.MessageBox.Show("PieChart не инициализирован!", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Настройка линейного графика
                cartesianChart_.Series = new SeriesCollection();
                cartesianChart_.AxisX.Clear();
                cartesianChart_.AxisX.Add(new Axis
                {
                    Title = "Дата",
                    LabelsRotation = 15,
                    Separator = new Separator { Step = 1 }
                });
                cartesianChart_.AxisY.Clear();
                cartesianChart_.AxisY.Add(new Axis
                {
                    Title = "Сумма (₽)",
                    LabelFormatter = value => value.ToString("N0")
                });
                cartesianChart_.LegendLocation = LegendLocation.Top;

                // Настройка круговой диаграммы
                pieChart_.Series = new SeriesCollection();
                pieChart_.InnerRadius = 50;
                pieChart_.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Ошибка настройки графиков: {ex.Message}", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление графиков
        /// </summary>
        public void UpdateCharts(DateTime startDate, DateTime endDate)
        {
            if (cartesianChart_ == null || pieChart_ == null)
            {
                return;
            }

            try
            {
                List<Sale> sales = null;
                try
                {
                    sales = loader_.LoadSales()?.ToList();
                }
                catch (NotImplementedException)
                {
                    // Метод не реализован - просто выходим
                    return;
                }
                catch (Exception)
                {
                    return;
                }

                if (sales == null || sales.Count == 0)
                {
                    ClearCharts();
                    ShowNoDataMessage("Нет данных для отображения");
                    return;
                }

                var filteredSales = sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();

                if (filteredSales.Count == 0)
                {
                    ClearCharts();
                    ShowNoDataMessage("Нет данных за выбранный период");
                    return;
                }

                UpdateCartesianChart(filteredSales);
                UpdatePieChart(filteredSales);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления графиков: {ex.Message}");
            }
        }

        /// <summary>
        /// Обновление линейного графика
        /// </summary>
        private void UpdateCartesianChart(List<Sale> sales)
        {
            if (cartesianChart_ == null) return;

            var dailySales = sales
                .GroupBy(s => s.SaleDate.Date)
                .OrderBy(g => g.Key)
                .Select(g => new { Date = g.Key, Total = g.Sum(s => s.TotalAmount) })
                .ToList();

            if (dailySales.Count > 0)
            {
                var chartValues = new ChartValues<ObservablePoint>();
                var labels = new List<string>();

                foreach (var item in dailySales)
                {
                    chartValues.Add(new ObservablePoint(
                        item.Date.ToOADate(),
                        (double)item.Total
                    ));
                    labels.Add(item.Date.ToString("dd.MM"));
                }

                cartesianChart_.Series.Clear();

                var lineSeries = new LineSeries
                {
                    Title = "Выручка",
                    Values = chartValues,
                    PointGeometrySize = 12,
                    PointForeground = new SolidColorBrush(Color.FromRgb(231, 76, 60)),
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = new SolidColorBrush(Color.FromRgb(46, 204, 113)),
                    StrokeThickness = 3,
                    LineSmoothness = 0.5
                };

                cartesianChart_.Series.Add(lineSeries);

                cartesianChart_.AxisX.Clear();
                cartesianChart_.AxisX.Add(new Axis
                {
                    Title = "Дата",
                    Labels = labels,
                    LabelsRotation = 15,
                    Separator = new Separator { Step = 1 }
                });

                cartesianChart_.AxisY.Clear();
                cartesianChart_.AxisY.Add(new Axis
                {
                    Title = "Сумма (₽)",
                    LabelFormatter = value => value.ToString("N0")
                });
            }
        }

        /// <summary>
        /// Обновление круговой диаграммы
        /// </summary>
        private void UpdatePieChart(List<Sale> sales)
        {
            if (pieChart_ == null) return;

            var categorySales = new Dictionary<string, decimal>();
            foreach (var sale in sales)
            {
                if (sale.Items != null)
                {
                    foreach (var item in sale.Items)
                    {
                        if (categorySales.ContainsKey(item.Category))
                            categorySales[item.Category] += item.TotalPrice;
                        else
                            categorySales[item.Category] = item.TotalPrice;
                    }
                }
            }

            pieChart_.Series.Clear();

            if (categorySales.Count > 0)
            {
                var colors = new[]
                {
                    Color.FromRgb(231, 76, 60),
                    Color.FromRgb(46, 204, 113),
                    Color.FromRgb(52, 152, 219),
                    Color.FromRgb(241, 196, 15),
                    Color.FromRgb(155, 89, 182),
                    Color.FromRgb(26, 188, 156),
                    Color.FromRgb(230, 126, 34),
                    Color.FromRgb(149, 165, 166)
                };

                int colorIndex = 0;
                foreach (var cat in categorySales)
                {
                    var series = new PieSeries
                    {
                        Title = cat.Key,
                        Values = new ChartValues<ObservableValue> { new ObservableValue((double)cat.Value) },
                        DataLabels = true,
                        LabelPosition = PieLabelPosition.InsideSlice,
                        FontSize = 12,
                        Stroke = new SolidColorBrush(System.Windows.Media.Colors.White),
                        StrokeThickness = 2
                    };

                    if (colorIndex < colors.Length)
                    {
                        series.Fill = new SolidColorBrush(colors[colorIndex]);
                    }
                    colorIndex++;

                    pieChart_.Series.Add(series);
                }
            }
            else
            {
                pieChart_.Series.Add(new PieSeries
                {
                    Title = "Нет данных",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(1) },
                    DataLabels = true,
                    LabelPosition = PieLabelPosition.InsideSlice,
                    Fill = new SolidColorBrush(System.Windows.Media.Colors.Gray)
                });
            }
        }

        /// <summary>
        /// Очистка графиков
        /// </summary>
        public void ClearCharts()
        {
            if (cartesianChart_ != null)
            {
                cartesianChart_.Series.Clear();
            }

            if (pieChart_ != null)
            {
                pieChart_.Series.Clear();
            }
        }

        /// <summary>
        /// Показать сообщение "Нет данных"
        /// </summary>
        private void ShowNoDataMessage(string message)
        {
            if (cartesianChart_ == null) return;

            cartesianChart_.Series.Add(new LineSeries
            {
                Title = message,
                Values = new ChartValues<double> { 0 },
                PointGeometrySize = 0,
                Stroke = new SolidColorBrush(System.Windows.Media.Colors.Gray),
                StrokeThickness = 1,
                Fill = System.Windows.Media.Brushes.Transparent
            });
        }
    }
}