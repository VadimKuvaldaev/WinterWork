using ComputerStoreLib;
using ComputerStoreLib.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComputerStore
{
    public partial class MainForm : Form
    {
        private User currentUser_;
        private string connString_;
        private CartManager cartManager_;
        private ProductRepository productRepo_;
        private SaleRepository saleRepo_;
        private AnalyticsService analyticsService_;
        private ProductFilterService filterService_;
        private List<ProductItem> allProducts_;

        // BindingSource для корзины и склада
        private BindingSource cartBindingSource_ = new BindingSource();
        private BindingSource productsBindingSource_ = new BindingSource();

        public MainForm(User user, string connString)
        {
            InitializeComponent();
            currentUser_ = user;
            connString_ = connString;

            productRepo_ = new ProductRepository(connString);
            saleRepo_ = new SaleRepository(connString);

            cartManager_ = new CartManager(productRepo_, saleRepo_);
            analyticsService_ = new AnalyticsService(saleRepo_);
            filterService_ = new ProductFilterService(productRepo_);

            GridUIHelper.ConfigureProductsForSaleGrid(ProductsForSaleDataGridView);
            GridUIHelper.ConfigureCartGrid(CartDataGridView);
            GridUIHelper.ConfigureInventoryGrid(ProductsDataGridView);
            GridUIHelper.ConfigureSalesGrid(SalesDataGridView);

            // Привязываем BindingSource к таблицам
            CartDataGridView.DataSource = cartBindingSource_;
            ProductsForSaleDataGridView.DataSource = productsBindingSource_;
            ProductsDataGridView.DataSource = productsBindingSource_;

            // Подписка на события завершения привязки данных для подсветки
            this.ProductsForSaleDataGridView.DataBindingComplete += (s, e) =>
            {
                if (allProducts_ != null)
                    GridUIHelper.HighlightRows(ProductsForSaleDataGridView, allProducts_);
            };
            this.ProductsDataGridView.DataBindingComplete += (s, e) =>
            {
                if (allProducts_ != null)
                    GridUIHelper.HighlightRows(ProductsDataGridView, allProducts_);
            };

            SetupUI();
            LoadInitialData();
            SetupCharts();
        }

        private void SetupUI()
        {
            UserInfoLabel.Text = $"Пользователь: {currentUser_.FullName ?? currentUser_.Login}";
            UserRoleLabel.Text = $"Роль: {currentUser_.RoleDisplayName}";

            if (currentUser_.Role == Role.Seller)
            {
                AddProductButton.Visible = false;
                DeleteProductButton.Visible = false;
                EditProductButton.Visible = false;
                ReportsTabPage.Visible = false;
            }

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            SearchTextBox.TextChanged -= SearchTextBox_TextChanged;
            CategoryFilterComboBox.SelectedIndexChanged -= CategoryFilterComboBox_SelectedIndexChanged;

            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            CategoryFilterComboBox.SelectedIndexChanged += CategoryFilterComboBox_SelectedIndexChanged;
        }

        private void LoadInitialData()
        {
            try
            {
                allProducts_ = productRepo_.GetAllProducts() ?? new List<ProductItem>();
                DisplayProducts(allProducts_);
                ProductCountLabel.Text = $"Всего товаров: {allProducts_.Count}";
                LoadCategories();
                UpdateCartDisplay();
                LoadReportsSafely();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка");
            }
        }

        private void DisplayProducts(List<ProductItem> products)
        {
            // Используем BindingSource вместо прямого присваивания DataSource
            productsBindingSource_.DataSource = products;
        }

        private void LoadCategories()
        {
            try
            {
                CategoryFilterComboBox.Items.Clear();
                CategoryFilterComboBox.Items.Add("Все категории");

                if (allProducts_ != null && allProducts_.Count > 0)
                {
                    var categories = allProducts_.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();
                    foreach (var cat in categories)
                        CategoryFilterComboBox.Items.Add(cat);
                }

                if (CategoryFilterComboBox.Items.Count > 0)
                    CategoryFilterComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки категорий: {ex.Message}");
            }
        }

        private void FilterProducts()
        {
            if (allProducts_ == null || allProducts_.Count == 0) return;

            try
            {
                string search = SearchTextBox?.Text?.Trim() ?? "";
                string category = CategoryFilterComboBox?.SelectedIndex > 0
                    ? CategoryFilterComboBox.SelectedItem?.ToString()
                    : null;

                var filtered = filterService_.FilterByNameAndCategory(search, category);
                DisplayProducts(filtered);
                ProductCountLabel.Text = $"Всего товаров: {filtered.Count}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка фильтрации: {ex.Message}");
            }
        }

        private void UpdateCartDisplay()
        {
            // Используем BindingSource для корзины
            cartBindingSource_.DataSource = null;
            cartBindingSource_.DataSource = cartManager_.GetCart().Items;

            CartTotalLabel.Text = $"Итого: {cartManager_.GetCart().TotalSum:C}";
            CartCountLabel.Text = $"Позиций: {cartManager_.GetCart().Count}";
            CheckoutButton.Enabled = !cartManager_.GetCart().IsEmpty;
        }

        private void LoadReportsSafely()
        {
            try
            {
                var allSales = saleRepo_.GetSalesByPeriod(DateTime.MinValue, DateTime.MaxValue);
                if (allSales.Count > 0)
                {
                    DisplaySales(allSales);
                    var minDate = allSales.Min(s => s.SaleDate);
                    var maxDate = allSales.Max(s => s.SaleDate);
                    UpdateCharts(minDate, maxDate);
                }
                else
                {
                    ClearSalesDisplay();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки отчетов: {ex.Message}");
                ClearSalesDisplay();
            }
        }

        private void DisplaySales(List<Sale> sales)
        {
            SalesDataGridView.DataSource = null;
            SalesDataGridView.DataSource = sales;
            SalesCountLabel.Text = $"Всего продаж: {sales.Count}";
            TotalRevenueLabel.Text = $"Общая выручка: {sales.Sum(s => s.TotalAmount):C}";
        }

        private void ClearSalesDisplay()
        {
            SalesDataGridView.DataSource = null;
            SalesCountLabel.Text = "Всего продаж: 0";
            TotalRevenueLabel.Text = "Общая выручка: 0 ₽";
        }

        private void SetupCharts()
        {
            try
            {
                SalesDynamicsCartesianChart.Series = new SeriesCollection();
                SalesDynamicsCartesianChart.AxisX.Clear();
                SalesDynamicsCartesianChart.AxisX.Add(new Axis { Title = "Дата", LabelsRotation = 15 });
                SalesDynamicsCartesianChart.AxisY.Clear();
                SalesDynamicsCartesianChart.AxisY.Add(new Axis { Title = "Сумма (₽)", LabelFormatter = value => value.ToString("N0") });

                SalesCategoryPieChart.Series = new SeriesCollection();
                SalesCategoryPieChart.InnerRadius = 50;
                SalesCategoryPieChart.LegendLocation = LegendLocation.Right;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка настройки графиков: {ex.Message}");
            }
        }

        private void UpdateCharts(DateTime startDate, DateTime endDate)
        {
            try
            {
                var dailySales = analyticsService_.GroupSalesByDays(startDate, endDate);
                if (dailySales.Count > 0)
                {
                    var chartValues = new ChartValues<ObservablePoint>();
                    var labels = new List<string>();

                    foreach (var item in dailySales)
                    {
                        chartValues.Add(new ObservablePoint(item.Key.ToOADate(), (double)item.Value));
                        labels.Add(item.Key.ToString("dd.MM"));
                    }

                    SalesDynamicsCartesianChart.Series.Clear();
                    SalesDynamicsCartesianChart.Series.Add(new LineSeries
                    {
                        Title = "Выручка",
                        Values = chartValues,
                        PointGeometrySize = 12,
                        PointForeground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(231, 76, 60)),
                        Fill = System.Windows.Media.Brushes.Transparent,
                        Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(46, 204, 113)),
                        StrokeThickness = 3,
                        LineSmoothness = 0.5
                    });

                    SalesDynamicsCartesianChart.AxisX.Clear();
                    SalesDynamicsCartesianChart.AxisX.Add(new Axis { Title = "Дата", Labels = labels, LabelsRotation = 15 });
                }

                var categorySales = analyticsService_.GroupSalesByCategory(startDate, endDate);
                SalesCategoryPieChart.Series.Clear();

                if (categorySales.Count > 0)
                {
                    var colors = new[]
                    {
                        Color.FromArgb(231, 76, 60), Color.FromArgb(46, 204, 113), Color.FromArgb(52, 152, 219),
                        Color.FromArgb(241, 196, 15), Color.FromArgb(155, 89, 182), Color.FromArgb(26, 188, 156),
                        Color.FromArgb(230, 126, 34), Color.FromArgb(149, 165, 166)
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
                            series.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(colors[colorIndex].R, colors[colorIndex].G, colors[colorIndex].B));
                        colorIndex++;
                        SalesCategoryPieChart.Series.Add(series);
                    }
                }
                else
                {
                    SalesCategoryPieChart.Series.Add(new PieSeries
                    {
                        Title = "Нет данных",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(1) },
                        DataLabels = true,
                        Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray)
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка обновления графиков: {ex.Message}");
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e) => FilterProducts();
        private void CategoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e) => FilterProducts();

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) Application.Exit();
        }

        private void RefreshButton_Click(object sender, EventArgs e) => LoadInitialData();

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

            if (cartManager_.AddToCart(product, quantity))
            {
                LoadInitialData();
                QuantityNumericUpDown.Value = 1;
                MessageBox.Show("Товар добавлен в корзину", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось добавить товар (проверьте остаток)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemoveFromCartButton_Click(object sender, EventArgs e)
        {
            if (CartDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар в корзине", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = CartDataGridView.SelectedRows[0].DataBoundItem as CartItem;
            if (item == null) return;

            if (cartManager_.RemoveFromCart(item))
            {
                LoadInitialData();
                MessageBox.Show($"Товар '{item.Product.Name}' удален из корзины", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            cartManager_.ClearCart();
            LoadInitialData();
            MessageBox.Show("Корзина очищена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            if (cartManager_.Checkout(currentUser_))
            {
                LoadInitialData();
                LoadReportsSafely();
                MessageBox.Show("Продажа оформлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Корзина пуста или произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = StartDatePicker.Value.Date;
            DateTime endDate = EndDatePicker.Value.Date.AddDays(1).AddSeconds(-1);

            if (startDate > endDate)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sales = saleRepo_.GetSalesByPeriod(startDate, endDate);
            if (sales.Count == 0)
            {
                MessageBox.Show("Нет продаж за выбранный период", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearSalesDisplay();
                SalesDynamicsCartesianChart.Series.Clear();
                SalesCategoryPieChart.Series.Clear();
                return;
            }

            DisplaySales(sales);
            UpdateCharts(startDate, endDate);

            decimal totalRevenue = sales.Sum(s => s.TotalAmount);
            MessageBox.Show($"Отчет сформирован!\nПродаж: {sales.Count}\nВыручка: {totalRevenue:C}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProductEditForm editForm = new ProductEditForm(null, connString_);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadInitialData();
                MessageBox.Show("Товар успешно добавлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditProductButton_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = ProductsDataGridView.SelectedRows[0].DataBoundItem as ProductItem;
            if (product != null)
            {
                ProductEditForm editForm = new ProductEditForm(product, connString_);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadInitialData();
                    MessageBox.Show("Товар успешно обновлен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = ProductsDataGridView.SelectedRows[0].DataBoundItem as ProductItem;
            if (product != null)
            {
                if (product.Quantity > 0)
                {
                    var result = MessageBox.Show($"Остаток {product.Quantity} шт. Удалить?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;
                }

                if (productRepo_.DeleteProduct(product.Id))
                {
                    LoadInitialData();
                    MessageBox.Show("Товар удалён", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}