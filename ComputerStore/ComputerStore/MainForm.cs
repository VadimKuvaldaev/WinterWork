using ComputerStoreLib;
using ComputerStoreLib.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerStore
{
    public partial class MainForm : Form
    {
        // Загрузчик данных из базы PostgreSQL
        private PgComputerStoreLoader loader_;
        // Текущий авторизованный пользователь
        private User currentUser_;
        // Корзина для товаров
        private Cart cart_ = new Cart();

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        /// <param name="loader">Загрузчик данных из БД</param>
        /// <param name="currentUser">Авторизованный пользователь</param>
        public MainForm(PgComputerStoreLoader loader, User currentUser)
        {
            InitializeComponent();
            loader_ = loader;
            currentUser_ = currentUser;

            ConfigureDataGridViews();
            LoadData();
            SetupUI();
            ConfigureCharts();
        }

        // ==================== НАСТРОЙКА ТАБЛИЦ ====================

        /// <summary>
        /// Настройка всех DataGridView на форме
        /// </summary>
        private void ConfigureDataGridViews()
        {
            // ===== ProductsForSaleDataGridView (Каталог для продаж) =====
            ProductsForSaleDataGridView.AutoGenerateColumns = false;
            ProductsForSaleDataGridView.Columns.Clear();
            ProductsForSaleDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id",
                    HeaderText = "ID",
                    DataPropertyName = "Id",
                    Width = 40
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Name",
                    HeaderText = "Наименование",
                    DataPropertyName = "Name",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Category",
                    HeaderText = "Категория",
                    DataPropertyName = "Category",
                    Width = 120
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Цена (₽)",
                    DataPropertyName = "Price",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "В наличии",
                    DataPropertyName = "Quantity",
                    Width = 80
                }
            });

            // ===== CartDataGridView (Корзина) =====
            CartDataGridView.AutoGenerateColumns = false;
            CartDataGridView.Columns.Clear();
            CartDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductName",
                    HeaderText = "Наименование",
                    DataPropertyName = "ProductName",
                    Width = 200
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Price",
                    HeaderText = "Цена (₽)",
                    DataPropertyName = "Price",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Quantity",
                    HeaderText = "Количество",
                    DataPropertyName = "Quantity",
                    Width = 80
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalPrice",
                    HeaderText = "Итого (₽)",
                    DataPropertyName = "TotalPrice",
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                }
            });

            // ===== ProductsDataGridView (Склад) =====
            ProductsDataGridView.AutoGenerateColumns = false;
            ProductsDataGridView.Columns.Clear();
            ProductsDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Наименование", DataPropertyName = "Name", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Категория", DataPropertyName = "Category", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Цена (₽)", DataPropertyName = "Price", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Остаток", DataPropertyName = "Quantity", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "TotalValue", HeaderText = "Общая стоимость (₽)", DataPropertyName = "TotalValue", Width = 150, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
            });

            // ===== SalesDataGridView (Отчеты) =====
            SalesDataGridView.AutoGenerateColumns = false;
            SalesDataGridView.Columns.Clear();
            SalesDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "№", DataPropertyName = "Id", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "SaleDate", HeaderText = "Дата", DataPropertyName = "SaleDate", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "UserName", HeaderText = "Продавец", DataPropertyName = "UserName", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "TotalAmount", HeaderText = "Сумма (₽)", DataPropertyName = "TotalAmount", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } }
            });

            // Подписка на форматирование для подсветки остатков
            ProductsDataGridView.CellFormatting += ProductsDataGridView_CellFormatting;
            ProductsForSaleDataGridView.CellFormatting += ProductsForSaleDataGridView_CellFormatting;

            // Настройка выделения строк
            ProductsForSaleDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CartDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ==================== ПОДСВЕТКА ТОВАРОВ ====================

        /// <summary>
        /// Обработчик форматирования ячеек на складе
        /// </summary>
        private void ProductsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = ProductsDataGridView.Rows[e.RowIndex];
            if (row.DataBoundItem is ProductItem product)
            {
                HighlightProductRow(row, product.Quantity);
            }
        }

        /// <summary>
        /// Обработчик форматирования ячеек в каталоге
        /// </summary>
        private void ProductsForSaleDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = ProductsForSaleDataGridView.Rows[e.RowIndex];
            if (row.DataBoundItem is ProductItem product)
            {
                HighlightProductRow(row, product.Quantity);
            }
        }

        /// <summary>
        /// Подсветка строки в зависимости от количества товара
        /// </summary>
        /// <param name="row">Строка таблицы</param>
        /// <param name="quantity">Количество товара</param>
        private void HighlightProductRow(DataGridViewRow row, int quantity)
        {
            if (quantity == 0)
            {
                // Красный - товар отсутствует на складе
                row.DefaultCellStyle.BackColor = Color.LightCoral;
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.Red;
                row.DefaultCellStyle.SelectionForeColor = Color.White;
            }
            else if (quantity <= 5)
            {
                // Желтый - критический остаток (1-5 шт.)
                row.DefaultCellStyle.BackColor = Color.LightYellow;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.Gold;
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            else
            {
                // Белый - нормальный остаток (> 5 шт.)
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                row.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        // ==================== НАСТРОЙКА ГРАФИКОВ ====================

        /// <summary>
        /// Настройка графиков (CartesianChart и PieChart)
        /// </summary>
        private void ConfigureCharts()
        {
            // Настройка линейного графика (динамика продаж)
            cartesianChart1.Series = new SeriesCollection();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Дата",
                LabelsRotation = 15,
                Separator = new Separator { Step = 1 }
            });
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Сумма (₽)",
                LabelFormatter = value => value.ToString("N0")
            });
            cartesianChart1.LegendLocation = LegendLocation.Top;

            // Настройка круговой диаграммы (распределение по категориям)
            pieChart1.Series = new SeriesCollection();
            pieChart1.InnerRadius = 50;
            pieChart1.LegendLocation = LegendLocation.Right;
        }

        // ==================== ОБНОВЛЕНИЕ ГРАФИКОВ ====================

        /// <summary>
        /// Обновляет графики на вкладке "Отчеты"
        /// </summary>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        private void UpdateCharts(DateTime startDate, DateTime endDate)
        {
            try
            {
                var sales = loader_.LoadSales();
                if (sales == null || sales.Count == 0)
                {
                    cartesianChart1.Series.Clear();
                    pieChart1.Series.Clear();
                    ShowNoDataMessage("Нет данных для отображения");
                    return;
                }

                // Фильтруем продажи по дате
                var filteredSales = sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();

                if (filteredSales.Count == 0)
                {
                    cartesianChart1.Series.Clear();
                    pieChart1.Series.Clear();
                    ShowNoDataMessage("Нет данных за выбранный период");
                    return;
                }

                // ===== CartesianChart - Динамика продаж по дням =====
                var dailySales = filteredSales
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

                    cartesianChart1.Series.Clear();

                    var lineSeries = new LineSeries
                    {
                        Title = "Выручка",
                        Values = chartValues,
                        PointGeometrySize = 12,
                        PointForeground = new System.Windows.Media.SolidColorBrush(
                            System.Windows.Media.Color.FromRgb(231, 76, 60) // Красный цвет точек
                        ),
                        Fill = System.Windows.Media.Brushes.Transparent,
                        Stroke = new System.Windows.Media.SolidColorBrush(
                            System.Windows.Media.Color.FromRgb(46, 204, 113) // Зеленый цвет линии
                        ),
                        StrokeThickness = 3,
                        LineSmoothness = 0.5
                    };

                    cartesianChart1.Series.Add(lineSeries);

                    // Настройка оси X
                    cartesianChart1.AxisX.Clear();
                    cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = "Дата",
                        Labels = labels,
                        LabelsRotation = 15,
                        Separator = new Separator { Step = 1 }
                    });

                    // Настройка оси Y
                    cartesianChart1.AxisY.Clear();
                    cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = "Сумма (₽)",
                        LabelFormatter = value => value.ToString("N0")
                    });
                }

                // ===== PieChart - Распределение продаж по категориям =====
                var categorySales = new Dictionary<string, decimal>();
                foreach (var sale in filteredSales)
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

                pieChart1.Series.Clear();

                if (categorySales.Count > 0)
                {
                    // Цвета для секторов диаграммы
                    var colors = new[]
                    {
                        System.Windows.Media.Color.FromRgb(231, 76, 60),   // Красный
                        System.Windows.Media.Color.FromRgb(46, 204, 113),   // Зеленый
                        System.Windows.Media.Color.FromRgb(52, 152, 219),   // Синий
                        System.Windows.Media.Color.FromRgb(241, 196, 15),   // Желтый
                        System.Windows.Media.Color.FromRgb(155, 89, 182),   // Фиолетовый
                        System.Windows.Media.Color.FromRgb(26, 188, 156),   // Бирюзовый
                        System.Windows.Media.Color.FromRgb(230, 126, 34),   // Оранжевый
                        System.Windows.Media.Color.FromRgb(149, 165, 166)   // Серый
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
                            Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White),
                            StrokeThickness = 2
                        };

                        if (colorIndex < colors.Length)
                        {
                            series.Fill = new System.Windows.Media.SolidColorBrush(colors[colorIndex]);
                        }
                        colorIndex++;

                        pieChart1.Series.Add(series);
                    }
                }
                else
                {
                    // Если нет данных - показываем заглушку
                    pieChart1.Series.Add(new PieSeries
                    {
                        Title = "Нет данных",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(1) },
                        DataLabels = true,
                        LabelPosition = PieLabelPosition.InsideSlice,
                        Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray)
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления графиков: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Показывает сообщение "Нет данных" на графике
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        private void ShowNoDataMessage(string message)
        {
            cartesianChart1.Series.Add(new LineSeries
            {
                Title = message,
                Values = new ChartValues<double> { 0 },
                PointGeometrySize = 0,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray),
                StrokeThickness = 1,
                Fill = System.Windows.Media.Brushes.Transparent
            });
        }

        // ==================== ЗАГРУЗКА ДАННЫХ ====================

        /// <summary>
        /// Загрузка всех данных при открытии формы
        /// </summary>
        private void LoadData()
        {
            try
            {
                var products = loader_.LoadProducts();

                // Если в БД нет товаров - показываем тестовые данные
                if (products == null || products.Count == 0)
                {
                    var testData = new List<ProductItem>
                    {
                        new ProductItem { Id = 1, Name = "Intel Core i9-13900K", Category = "Процессоры", Price = 85000, Quantity = 10 },
                        new ProductItem { Id = 2, Name = "NVIDIA RTX 4090", Category = "Видеокарты", Price = 180000, Quantity = 5 },
                        new ProductItem { Id = 3, Name = "Kingston DDR5 32GB", Category = "Оперативная память", Price = 35000, Quantity = 20 },
                        new ProductItem { Id = 4, Name = "Samsung 990 PRO 2TB", Category = "Накопители SSD", Price = 45000, Quantity = 15 },
                        new ProductItem { Id = 5, Name = "ASUS ROG Maximus Z790", Category = "Материнские платы", Price = 65000, Quantity = 6 },
                        new ProductItem { Id = 6, Name = "Тестовый товар (0 шт)", Category = "Тест", Price = 1000, Quantity = 0 },
                        new ProductItem { Id = 7, Name = "Тестовый товар (2 шт)", Category = "Тест", Price = 2000, Quantity = 2 },
                    };

                    ProductsForSaleDataGridView.DataSource = testData;
                    ProductsDataGridView.DataSource = testData;
                    ProductCountLabel.Text = $"Всего товаров: {testData.Count} (тестовые)";
                    return;
                }

                // Отображаем товары
                ProductsForSaleDataGridView.DataSource = products;
                ProductsDataGridView.DataSource = products;
                ProductCountLabel.Text = $"Всего товаров: {products.Count}";

                LoadSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка");
            }
        }

        // ==================== НАСТРОЙКА UI ====================

        /// <summary>
        /// Настройка пользовательского интерфейса
        /// </summary>
        private void SetupUI()
        {
            // Отображение информации о пользователе
            UserInfoLabel.Text = $"Пользователь: {currentUser_.FullName ?? currentUser_.Login}";
            UserRoleLabel.Text = $"Роль: {currentUser_.RoleDisplayName}";

            // Настройка доступа для продавца
            if (currentUser_.Role == Role.Seller)
            {
                AddProductButton.Visible = false;
                DeleteProductButton.Visible = false;
                EditProductButton.Visible = false;
                ReportsTabPage.Visible = false;
            }

            // ---- БЕЗОПАСНАЯ ПОДПИСКА НА СОБЫТИЯ ----
            // Сначала отписываемся, чтобы избежать двойной подписки
            LogoutButton.Click -= (s, e) => { };
            LogoutButton.Click += (s, e) =>
            {
                var result = MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { Application.Exit(); }
            };

            RefreshButton.Click -= (s, e) => LoadData();
            RefreshButton.Click += (s, e) => LoadData();

            AddToCartButton.Click -= AddToCartButton_Click;
            AddToCartButton.Click += AddToCartButton_Click;

            RemoveFromCartButton.Click -= RemoveFromCartButton_Click;
            RemoveFromCartButton.Click += RemoveFromCartButton_Click;

            ClearCartButton.Click -= (s, e) => { cart_.Clear(); UpdateCartDisplay(); };
            ClearCartButton.Click += (s, e) => { cart_.Clear(); UpdateCartDisplay(); };

            CheckoutButton.Click -= CheckoutButton_Click;
            CheckoutButton.Click += CheckoutButton_Click;

            GenerateReportButton.Click -= GenerateReportButton_Click;
            GenerateReportButton.Click += GenerateReportButton_Click;

            SearchTextBox.TextChanged -= (s, e) => FilterProducts();
            SearchTextBox.TextChanged += (s, e) => FilterProducts();

            CategoryFilterComboBox.SelectedIndexChanged -= (s, e) => FilterProducts();
            CategoryFilterComboBox.SelectedIndexChanged += (s, e) => FilterProducts();

            cart_.PropertyChanged -= (s, e) => UpdateCartDisplay();
            cart_.PropertyChanged += (s, e) => UpdateCartDisplay();

            LoadCategories();
            UpdateCartDisplay();
            LoadSales();
        }

        /// <summary>
        /// Загрузка категорий товаров в выпадающий список
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                var products = loader_.LoadProducts();
                if (products != null && products.Count > 0)
                {
                    var categories = products.Select(p => p.Category).Distinct().ToList();
                    CategoryFilterComboBox.Items.Clear();
                    CategoryFilterComboBox.Items.Add("Все категории");
                    foreach (var cat in categories)
                        CategoryFilterComboBox.Items.Add(cat);
                    CategoryFilterComboBox.SelectedIndex = 0;
                }
            }
            catch { }
        }

        /// <summary>
        /// Фильтрация товаров по поисковому запросу и категории
        /// </summary>
        private void FilterProducts()
        {
            try
            {
                var products = loader_.LoadProducts();
                if (products == null) return;

                var filtered = products.AsEnumerable();

                // Фильтр по названию
                string search = SearchTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(search))
                    filtered = filtered.Where(p => p.Name.ToLower().Contains(search.ToLower()));

                // Фильтр по категории
                if (CategoryFilterComboBox.SelectedIndex > 0)
                {
                    string category = CategoryFilterComboBox.SelectedItem.ToString();
                    filtered = filtered.Where(p => p.Category == category);
                }

                var result = filtered.ToList();
                ProductsForSaleDataGridView.DataSource = result;
                ProductsDataGridView.DataSource = result;
                ProductCountLabel.Text = $"Всего товаров: {result.Count}";
            }
            catch { }
        }

        /// <summary>
        /// Обновление отображения корзины
        /// </summary>
        private void UpdateCartDisplay()
        {
            CartDataGridView.DataSource = null;
            CartDataGridView.DataSource = cart_.Items;
            CartTotalLabel.Text = $"Итого: {cart_.TotalSum:C}";
            CartCountLabel.Text = $"Позиций: {cart_.Count}";
            CheckoutButton.Enabled = !cart_.IsEmpty;
        }

        // ==================== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ДЛЯ РАБОТЫ СО СКЛАДОМ ====================

        /// <summary>
        /// Списание товара со склада при добавлении в корзину
        /// </summary>
        /// <param name="productId">ID товара</param>
        /// <param name="quantity">Количество для списания</param>
        /// <returns>True - успешно, False - ошибка</returns>
        private bool ReserveProductFromStock(int productId, int quantity)
        {
            var product = loader_.LoadProducts().FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show($"Товар с ID {productId} не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (product.Quantity < quantity)
            {
                MessageBox.Show($"Недостаточно товара '{product.Name}'. Доступно: {product.Quantity} шт.",
                               "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Списание со склада
            product.Quantity -= quantity;
            loader_.UpdateProduct(product);
            return true;
        }

        /// <summary>
        /// Возврат товара на склад при удалении из корзины
        /// </summary>
        /// <param name="productId">ID товара</param>
        /// <param name="quantity">Количество для возврата</param>
        private void ReturnProductToStock(int productId, int quantity)
        {
            var product = loader_.LoadProducts().FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show($"Товар с ID {productId} не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Возврат на склад
            product.Quantity += quantity;
            loader_.UpdateProduct(product);
        }

        // ==================== КНОПКИ КОРЗИНЫ ====================

        /// <summary>
        /// Обработчик кнопки "Добавить в корзину"
        /// </summary>
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (ProductsForSaleDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = ProductsForSaleDataGridView.SelectedRows[0].DataBoundItem as ProductItem;
            if (product == null) return;

            int quantity = (int)QuantityNumericUpDown.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("Количество должно быть > 0", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем остаток на складе
            if (product.Quantity < quantity)
            {
                MessageBox.Show($"На складе только {product.Quantity} шт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // СПИСЫВАЕМ ТОВАР СО СКЛАДА
                if (!ReserveProductFromStock(product.Id, quantity))
                    return;

                // Добавляем в корзину
                cart_.AddItem(product, quantity);

                // Обновляем отображение склада
                LoadInventory();

                MessageBox.Show($"Товар '{product.Name}' добавлен в корзину\nКоличество: {quantity} шт.\nОстаток на складе: {product.Quantity - quantity} шт.",
                               "Успех",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                QuantityNumericUpDown.Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить из корзины"
        /// </summary>
        private void RemoveFromCartButton_Click(object sender, EventArgs e)
        {
            if (CartDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар в корзине", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = CartDataGridView.SelectedRows[0].DataBoundItem as CartItem;
            if (item == null) return;

            int currentQuantity = item.Quantity;
            string productName = item.ProductName;
            int productId = item.Product.Id;

            if (currentQuantity > 1)
            {
                // Создаем кастомную форму для выбора действия
                var form = new Form();
                form.Text = "Удаление из корзины";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Size = new Size(450, 140);

                var label = new Label();
                label.Text = $"В корзине {currentQuantity} шт. товара '{productName}'.\nВыберите действие:";
                label.Location = new Point(20, 20);
                label.Size = new Size(400, 50);
                label.Font = new Font("Segoe UI", 10);
                form.Controls.Add(label);

                var btnDeleteOne = new Button();
                btnDeleteOne.Text = "Удалить 1 единицу";
                btnDeleteOne.Location = new Point(20, 70);
                btnDeleteOne.Size = new Size(120, 25);
                btnDeleteOne.DialogResult = DialogResult.Yes;
                form.Controls.Add(btnDeleteOne);

                var btnDeleteAll = new Button();
                btnDeleteAll.Text = "Удалить все";
                btnDeleteAll.Location = new Point(155, 70);
                btnDeleteAll.Size = new Size(120, 25);
                btnDeleteAll.DialogResult = DialogResult.No;
                form.Controls.Add(btnDeleteAll);

                var btnCancel = new Button();
                btnCancel.Text = "Отмена";
                btnCancel.Location = new Point(290, 70);
                btnCancel.Size = new Size(120, 25);
                btnCancel.DialogResult = DialogResult.Cancel;
                form.Controls.Add(btnCancel);

                var result = form.ShowDialog();

                if (result == DialogResult.Yes)
                {
                    // Удаляем 1 единицу - ВОЗВРАЩАЕМ НА СКЛАД
                    ReturnProductToStock(productId, 1);

                    var cartItem = cart_.Items.First(i => i.Product.Id == productId);
                    cartItem.Quantity -= 1;
                    if (cartItem.Quantity == 0)
                    {
                        cart_.RemoveItem(productId);
                    }
                    UpdateCartDisplay();
                    LoadInventory();
                    MessageBox.Show($"Удалена 1 единица товара '{productName}'\nТовар возвращен на склад", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    // Удаляем весь товар - ВОЗВРАЩАЕМ ВСЁ НА СКЛАД
                    ReturnProductToStock(productId, currentQuantity);

                    cart_.RemoveItem(productId);
                    UpdateCartDisplay();
                    LoadInventory();
                    MessageBox.Show($"Товар '{productName}' полностью удален из корзины\n{currentQuantity} шт. возвращено на склад", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Cancel - ничего не делаем
            }
            else
            {
                var result = MessageBox.Show(
                    $"Удалить товар '{productName}' из корзины?\n(1 шт. будет возвращено на склад)",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // ВОЗВРАЩАЕМ НА СКЛАД
                    ReturnProductToStock(productId, 1);

                    cart_.RemoveItem(productId);
                    UpdateCartDisplay();
                    LoadInventory();
                    MessageBox.Show($"Товар '{productName}' удален из корзины\n1 шт. возвращено на склад", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки "Оформить продажу"
        /// </summary>
        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            if (cart_.IsEmpty)
            {
                MessageBox.Show("Корзина пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var sale = new Sale
                {
                    UserId = currentUser_.Id,
                    UserName = currentUser_.FullName ?? currentUser_.Login,
                    SaleDate = DateTime.Now,
                    Items = new BindingList<SaleItem>()
                };

                // Проверяем все товары в корзине
                foreach (var cartItem in cart_.Items)
                {
                    var product = loader_.LoadProducts().FirstOrDefault(p => p.Id == cartItem.Product.Id);
                    if (product == null)
                    {
                        MessageBox.Show($"Товар '{cartItem.ProductName}' не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Товар уже списан при добавлении в корзину
                    // Проверяем, что остаток не отрицательный
                    if (product.Quantity < 0)
                    {
                        MessageBox.Show($"Ошибка: отрицательный остаток товара '{product.Name}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    sale.Items.Add(new SaleItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Category = product.Category,
                        Price = product.Price,
                        Quantity = cartItem.Quantity,
                        TotalPrice = cartItem.TotalPrice
                    });

                    sale.TotalAmount += cartItem.TotalPrice;
                }

                // Сохраняем продажу в БД
                if (loader_.AddSale(sale))
                {
                    cart_.Clear();
                    LoadData();
                    LoadSales();
                    MessageBox.Show($"Продажа оформлена!\nСумма: {sale.TotalAmount:C}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления продажи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== МЕТОДЫ ДЛЯ СКЛАДА ====================

        /// <summary>
        /// Загрузка и отображение товаров на складе
        /// </summary>
        private void LoadInventory()
        {
            string searchTerm = SearchTextBox.Text.Trim();
            string category = CategoryFilterComboBox.SelectedItem?.ToString();

            var products = loader_.LoadProducts();
            if (products != null)
            {
                var filtered = products.AsEnumerable();

                if (!string.IsNullOrEmpty(searchTerm))
                    filtered = filtered.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));

                if (!string.IsNullOrEmpty(category) && category != "Все категории")
                    filtered = filtered.Where(p => p.Category == category);

                ProductsDataGridView.DataSource = null;
                ProductsDataGridView.DataSource = filtered.ToList();

                ProductsForSaleDataGridView.DataSource = null;
                ProductsForSaleDataGridView.DataSource = filtered.ToList();

                ProductCountLabel.Text = $"Всего товаров: {filtered.Count()}";
            }
        }

        /// <summary>
        /// Обработчик кнопки "Обновить"
        /// </summary>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadInventory();
            LoadSales();
        }

        /// <summary>
        /// Обработчик кнопки "Добавить товар"
        /// </summary>
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProductEditForm editForm = new ProductEditForm(null, loader_);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadInventory();
                MessageBox.Show("Товар успешно добавлен", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Обработчик кнопки "Редактировать товар"
        /// </summary>
        private void EditProductButton_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите товар", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = ProductsDataGridView.SelectedRows[0].DataBoundItem as ProductItem;
            if (product != null)
            {
                ProductEditForm editForm = new ProductEditForm(product, loader_);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadInventory();
                    MessageBox.Show("Товар успешно обновлен", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Обработчик кнопки "Удалить товар"
        /// </summary>
        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите товар", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = ProductsDataGridView.SelectedRows[0].DataBoundItem as ProductItem;
            if (product != null)
            {
                if (product.Quantity > 0)
                {
                    var result = MessageBox.Show($"Остаток {product.Quantity} шт. Удалить?",
                                                "Подтверждение удаления",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                        return;
                }

                if (loader_.DeleteProduct(product.Id))
                {
                    LoadInventory();
                    MessageBox.Show("Товар удалён", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // ==================== МЕТОДЫ ДЛЯ ОТЧЕТОВ ====================

        /// <summary>
        /// Загрузка и отображение продаж в отчетах
        /// </summary>
        private void LoadSales()
        {
            try
            {
                var sales = loader_.LoadSales();
                if (sales != null)
                {
                    SalesDataGridView.DataSource = null;
                    SalesDataGridView.DataSource = sales;
                    SalesCountLabel.Text = $"Всего продаж: {sales.Count}";

                    decimal totalRevenue = loader_.GetTotalRevenue();
                    TotalRevenueLabel.Text = $"Общая выручка: {totalRevenue:C}";

                    // Обновляем графики при загрузке
                    if (sales.Count > 0)
                    {
                        var minDate = sales.Min(s => s.SaleDate);
                        var maxDate = sales.Max(s => s.SaleDate);
                        UpdateCharts(minDate, maxDate);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отчетов: {ex.Message}", "Ошибка");
            }
        }

        /// <summary>
        /// Обработчик кнопки "Сформировать отчет"
        /// </summary>
        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate = StartDatePicker.Value.Date;
                DateTime endDate = EndDatePicker.Value.Date.AddDays(1).AddSeconds(-1);

                if (startDate > endDate)
                {
                    MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sales = loader_.LoadSales();

                if (sales == null || sales.Count == 0)
                {
                    MessageBox.Show("Нет продаж за выбранный период", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Фильтруем продажи по дате
                var filteredSales = sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();

                if (filteredSales.Count == 0)
                {
                    MessageBox.Show("Нет продаж за выбранный период", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SalesDataGridView.DataSource = null;
                    SalesCountLabel.Text = "Всего продаж: 0";
                    TotalRevenueLabel.Text = "Общая выручка: 0 ₽";
                    cartesianChart1.Series.Clear();
                    pieChart1.Series.Clear();
                    return;
                }

                // Обновляем таблицу
                SalesDataGridView.DataSource = null;
                SalesDataGridView.DataSource = filteredSales;
                SalesCountLabel.Text = $"Всего продаж: {filteredSales.Count}";

                decimal totalRevenue = filteredSales.Sum(s => s.TotalAmount);
                TotalRevenueLabel.Text = $"Общая выручка: {totalRevenue:C}";

                // Обновляем графики
                UpdateCharts(startDate, endDate);

                MessageBox.Show($"Отчет сформирован!\nПродаж: {filteredSales.Count}\nВыручка: {totalRevenue:C}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка формирования отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
