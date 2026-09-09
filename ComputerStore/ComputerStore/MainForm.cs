using ComputerStoreLib;
using ComputerStoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ComputerStore
{
    public partial class MainForm : Form
    {
        private PgComputerStoreLoader loader_;
        private User currentUser_;
        private Cart cart_ = new Cart();

        private ChartManager chartManager_;
        private CartManager cartManager_;
        private ReportManager reportManager_;
        private ProductFilter productFilter_;
        private List<ProductItem> allProducts_; // Храним все товары

        public MainForm(PgComputerStoreLoader loader, User currentUser)
        {
            InitializeComponent();
            loader_ = loader;
            currentUser_ = currentUser;

            // Инициализация
            InitializeManagers();
            SetupUI();
            LoadInitialData();
            SetupCharts();
        }

        private void InitializeManagers()
        {
            chartManager_ = new ChartManager(loader_, cartesianChart1, pieChart1);

            cartManager_ = new CartManager(
                loader_,
                cart_,
                CartDataGridView,
                CartTotalLabel,
                CartCountLabel,
                CheckoutButton);

            reportManager_ = new ReportManager(
                loader_,
                SalesDataGridView,
                SalesCountLabel,
                TotalRevenueLabel,
                chartManager_);

            productFilter_ = new ProductFilter(
                loader_,
                ProductsForSaleDataGridView,
                ProductsDataGridView,
                ProductCountLabel,
                SearchTextBox,
                CategoryFilterComboBox);
        }

        private void SetupUI()
        {
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

            // Подписка на события ПОСЛЕ загрузки данных
            SubscribeToEvents();

            // Подписка на изменение корзины
            cart_.PropertyChanged += (s, e) =>
            {
                if (cartManager_ != null)
                {
                    cartManager_.UpdateDisplay();
                }
            };
        }

        private void SubscribeToEvents()
        {
            // Отписываемся сначала (на случай повторной подписки)
            SearchTextBox.TextChanged -= SearchTextBox_TextChanged;
            CategoryFilterComboBox.SelectedIndexChanged -= CategoryFilterComboBox_SelectedIndexChanged;

            // Подписываемся заново
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;
            CategoryFilterComboBox.SelectedIndexChanged += CategoryFilterComboBox_SelectedIndexChanged;
        }

        private void LoadInitialData()
        {
            try
            {
                allProducts_ = loader_.LoadProducts()?.ToList() ?? new List<ProductItem>();

                // Отображаем товары
                DisplayProducts(allProducts_);
                ProductCountLabel.Text = $"Всего товаров: {allProducts_.Count}";

                // Загружаем категории
                LoadCategories();

                // Обновляем корзину
                cartManager_?.UpdateDisplay();

                // Загружаем отчеты
                LoadReportsSafely();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка");
            }
        }

        

        private void DisplayProducts(List<ProductItem> products)
        {
            ProductsForSaleDataGridView.DataSource = null;
            ProductsForSaleDataGridView.DataSource = products;

            ProductsDataGridView.DataSource = null;
            ProductsDataGridView.DataSource = products;
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
                    {
                        CategoryFilterComboBox.Items.Add(cat);
                    }
                }

                CategoryFilterComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки категорий: {ex.Message}");
            }
        }

        private void FilterProducts()
        {
            if (allProducts_ == null || allProducts_.Count == 0)
            {
                return;
            }

            try
            {
                var filtered = allProducts_.AsEnumerable();

                // Фильтр по названию
                string search = SearchTextBox?.Text?.Trim() ?? "";
                if (!string.IsNullOrEmpty(search))
                {
                    filtered = filtered.Where(p =>
                        p.Name?.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        p.Category?.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                    );
                }

                // Фильтр по категории
                if (CategoryFilterComboBox?.SelectedIndex > 0)
                {
                    string category = CategoryFilterComboBox.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(category))
                    {
                        filtered = filtered.Where(p => p.Category == category);
                    }
                }

                var result = filtered.ToList();
                DisplayProducts(result);
                ProductCountLabel.Text = $"Всего товаров: {result.Count}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка фильтрации: {ex.Message}");
            }
        }

        private void LoadReportsSafely()
        {
            try
            {
                reportManager_?.LoadSales();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка загрузки отчетов: {ex.Message}");

                if (SalesDataGridView != null)
                {
                    SalesDataGridView.DataSource = null;
                }
                if (SalesCountLabel != null)
                {
                    SalesCountLabel.Text = "Всего продаж: 0";
                }
                if (TotalRevenueLabel != null)
                {
                    TotalRevenueLabel.Text = "Общая выручка: 0 ₽";
                }
            }
        }

        private void SetupCharts()
        {
            try
            {
                chartManager_?.ConfigureCharts();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Ошибка настройки графиков: {ex.Message}");
            }
        }

        // ==================== ОБРАБОТЧИКИ СОБЫТИЙ ====================

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void CategoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { Application.Exit(); }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadInitialData();
        }

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
                // Обновляем данные
                LoadInitialData();
                QuantityNumericUpDown.Value = 1;
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
                // Обновляем данные
                LoadInitialData();
            }
        }

        private void ClearCartButton_Click(object sender, EventArgs e)
        {
            cartManager_.ClearCart();
            LoadInitialData();
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            if (cartManager_.Checkout(currentUser_))
            {
                LoadInitialData();
                LoadReportsSafely();
            }
        }

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = StartDatePicker.Value.Date;
            DateTime endDate = EndDatePicker.Value.Date.AddDays(1).AddSeconds(-1);
            reportManager_.GenerateReport(startDate, endDate);
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            ProductEditForm editForm = new ProductEditForm(null, loader_);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadInitialData();
                MessageBox.Show("Товар успешно добавлен", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

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
                    LoadInitialData();
                    MessageBox.Show("Товар успешно обновлен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

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
                    LoadInitialData();
                    MessageBox.Show("Товар удалён", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}