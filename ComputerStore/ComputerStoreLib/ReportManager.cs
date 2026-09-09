using ComputerStoreLib;
using ComputerStoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ComputerStoreLib
{
    /// <summary>
    /// Управление отчетами и продажами
    /// </summary>
    public class ReportManager
    {
        private readonly PgComputerStoreLoader loader_;
        private readonly DataGridView salesGrid_;
        private readonly Label salesCountLabel_;
        private readonly Label totalRevenueLabel_;
        private readonly ChartManager chartManager_;

        public ReportManager(
            PgComputerStoreLoader loader,
            DataGridView salesGrid,
            Label salesCountLabel,
            Label totalRevenueLabel,
            ChartManager chartManager)
        {
            loader_ = loader;
            salesGrid_ = salesGrid;
            salesCountLabel_ = salesCountLabel;
            totalRevenueLabel_ = totalRevenueLabel;
            chartManager_ = chartManager;
        }

        /// <summary>
        /// Загрузка всех продаж
        /// </summary>
        public void LoadSales()
        {
            try
            {
                var sales = LoadSalesSafely();

                if (sales.Count > 0)
                {
                    DisplaySales(sales);

                    var minDate = sales.Min(s => s.SaleDate);
                    var maxDate = sales.Max(s => s.SaleDate);
                    chartManager_?.UpdateCharts(minDate, maxDate);
                }
                else
                {
                    // Нет продаж - показываем пустую таблицу
                    ClearSalesDisplay();
                }
            }
            catch (Exception ex)
            {
                // Логируем ошибку, но не показываем MessageBox
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки отчетов: {ex.Message}");
                ClearSalesDisplay();
            }
        }

        /// <summary>
        /// Безопасная загрузка продаж
        /// </summary>
        private List<Sale> LoadSalesSafely()
        {
            try
            {
                var sales = loader_?.LoadSales();
                return sales?.ToList() ?? new List<Sale>();
            }
            catch (NotImplementedException)
            {
                // Метод не реализован - возвращаем пустой список
                System.Diagnostics.Debug.WriteLine("Метод LoadSales не реализован");
                return new List<Sale>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки продаж: {ex.Message}");
                return new List<Sale>();
            }
        }

        /// <summary>
        /// Формирование отчета за период
        /// </summary>
        public void GenerateReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sales = LoadSalesSafely();

                if (sales.Count == 0)
                {
                    ShowEmptyReport("Нет продаж за выбранный период");
                    return;
                }

                var filteredSales = sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();

                if (filteredSales.Count == 0)
                {
                    ShowEmptyReport("Нет продаж за выбранный период");
                    return;
                }

                DisplaySales(filteredSales);
                chartManager_?.UpdateCharts(startDate, endDate);

                decimal totalRevenue = filteredSales.Sum(s => s.TotalAmount);
                MessageBox.Show(
                    $"Отчет сформирован!\nПродаж: {filteredSales.Count}\nВыручка: {totalRevenue:C}",
                    "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка формирования отчета: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отображение списка продаж
        /// </summary>
        private void DisplaySales(List<Sale> sales)
        {
            if (salesGrid_ == null) return;

            salesGrid_.DataSource = null;
            salesGrid_.DataSource = sales;

            if (salesCountLabel_ != null)
            {
                salesCountLabel_.Text = $"Всего продаж: {sales.Count}";
            }

            if (totalRevenueLabel_ != null)
            {
                decimal totalRevenue = sales.Sum(s => s.TotalAmount);
                totalRevenueLabel_.Text = $"Общая выручка: {totalRevenue:C}";
            }
        }

        /// <summary>
        /// Очистка отображения продаж
        /// </summary>
        private void ClearSalesDisplay()
        {
            if (salesGrid_ != null)
            {
                salesGrid_.DataSource = null;
            }

            if (salesCountLabel_ != null)
            {
                salesCountLabel_.Text = "Всего продаж: 0";
            }

            if (totalRevenueLabel_ != null)
            {
                totalRevenueLabel_.Text = "Общая выручка: 0 ₽";
            }
        }

        /// <summary>
        /// Показать пустой отчет
        /// </summary>
        private void ShowEmptyReport(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearSalesDisplay();
            chartManager_?.ClearCharts();
        }
    }
}