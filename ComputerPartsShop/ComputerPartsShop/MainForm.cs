using ComputerPartsShopLibrary.Date;
using ComputerPartsShopLibrary.Model;
using ComputerPartsShopLibrary.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerPartsShop
{
    public partial class MainForm : Form
    {
        // Поля из диаграммы классов (image_180c3f.png)
        private UserManager _userManager;
        private WarehouseManager _warehouseManager;
        private Cart _cart;
        private CartPresenter _cartPresenter;
        private Database _db;
        Database addProduct = new Database();

        public MainForm(UserManager userManager)
        {
            InitializeComponent();

            // Инициализация объектов по схеме
            _userManager = userManager;
            _warehouseManager = new WarehouseManager();
            _db = new Database();
            _cart = new Cart();
            _cartPresenter = new CartPresenter(_cart, _warehouseManager, _db);

            // Настройка интерфейса и прав доступа
            ApplyPermissions();
            LoadInitialData();
        }

        // Метод переключения страниц из диаграммы (ShowPage)
        public void ShowPage(string pageName)
        {
            // Используем MainTabControl, созданный в дизайнере
            if (MainTabControl.TabPages.ContainsKey(pageName))
            {
                MainTabControl.SelectTab(pageName);
            }
        }

        // Разграничение прав доступа (Admin vs Seller)
        private void ApplyPermissions()
        {
            if (_userManager.currentUser.UserRole == Role.Seller)
            {
                // Скрываем админские кнопки на странице склада
                AddProductButton.Visible = false;
                DeleteProductButton.Visible = false;

                // Удаляем вкладку "Отчетность" для роли Seller
                if (MainTabControl.TabPages.ContainsKey("ReportsPage"))
                {
                    MainTabControl.TabPages.RemoveByKey("ReportsPage");
                }
            }
        }

        // --- СКЛАД (InventoryPage) ---

        private void UpgradeProductGrid(List<ProductItem> products)
        {
            ProductsDataGridView.DataSource = null;
            ProductsDataGridView.DataSource = products;

            // Алгоритм подсветки критического остатка (HighlightLowStock)
            foreach (DataGridViewRow row in ProductsDataGridView.Rows)
            {
                var item = (ProductItem)row.DataBoundItem;
                if (item.Quantity < 5) HighlightLowStock(item.Id);
            }
        }

        private void HighlightLowStock(int productId)
        {
            foreach (DataGridViewRow row in ProductsDataGridView.Rows)
            {
                if ((int)row.Cells["Id"].Value == productId)
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.CurrentRow != null)
            {
                int id = (int)ProductsDataGridView.CurrentRow.Cells["Id"].Value;
                _warehouseManager.RemoveProduct(id);
                UpgradeProductGrid(_warehouseManager.GetAllProducts());
            }
        }

        private void FilterCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = FilterCategoryComboBox.SelectedItem?.ToString();
            var filtered = _warehouseManager.GetProductsByCategory(category);
            UpgradeProductGrid(filtered);
        }

        // --- ПРОДАЖИ (SalesPage) ---

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (CatalogDataGridView.CurrentRow != null)
            {
                int id = (int)CatalogDataGridView.CurrentRow.Cells["Id"].Value;
                int qty = (int)QuantityNumericUpDown.Value;

                _cartPresenter.AddToCart(id, qty);
                UpgradeCartGrid(_cart.GetItems());
                TotalSumLabel_Update(_cart.GetTotalSum());
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                _cartPresenter.Checkout();
                MessageBox.Show("Продажа оформлена. Чек сформирован.");

                // Обновление UI после успешной продажи
                UpgradeCartGrid(new List<CartItem>());
                TotalSumLabel_Update(0);
                UpgradeProductGrid(_warehouseManager.GetAllProducts());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void TotalSumLabel_Update(decimal total)
        {
            lblTotalSum.Text = $"ИТОГО: {total} руб.";
        }

        private void UpgradeCartGrid(List<CartItem> cartItems)
        {
            CartDataGridView.DataSource = null;
            CartDataGridView.DataSource = cartItems;
        }

        // --- ОТЧЕТНОСТЬ (ReportsPage) ---

        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            UpdateReportCartesian();
            UpdateReportPie();
        }

        private void UpdateReportCartesian() { /* Логика графиков выручки */ }

        private void UpdateReportPie() { /* Логика диаграмм популярности */ }

        private void LoadInitialData()
        {
            UpgradeProductGrid(_warehouseManager.GetAllProducts());
            CatalogDataGridView.DataSource = _warehouseManager.GetAllProducts();
        }

        private void AddProductButton_Click_1(object sender, EventArgs e)
        {;

            AddProductForm addProductForm = new AddProductForm(addProduct);
            AddProductForm.Show();
            
        }
    }
}
