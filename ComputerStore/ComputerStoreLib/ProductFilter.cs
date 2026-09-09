using ComputerStoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerStoreLib
{
    /// <summary>
    /// Фильтрация и поиск товаров
    /// </summary>
    public class ProductFilter
    {
        private readonly PgComputerStoreLoader loader_;
        private readonly DataGridView productsForSaleGrid_;
        private readonly DataGridView productsGrid_;
        private readonly Label productCountLabel_;
        private readonly TextBox searchTextBox_;
        private readonly ComboBox categoryFilterComboBox_;

        public ProductFilter(
            PgComputerStoreLoader loader,
            DataGridView productsForSaleGrid,
            DataGridView productsGrid,
            Label productCountLabel,
            TextBox searchTextBox,
            ComboBox categoryFilterComboBox)
        {
            loader_ = loader;
            productsForSaleGrid_ = productsForSaleGrid;
            productsGrid_ = productsGrid;
            productCountLabel_ = productCountLabel;
            searchTextBox_ = searchTextBox;
            categoryFilterComboBox_ = categoryFilterComboBox;
        }

        public void LoadCategories()
        {
            try
            {
                var products = loader_.LoadProducts();
                if (products != null && products.Count > 0)
                {
                    var categories = products.Select(p => p.Category).Distinct().ToList();
                    categoryFilterComboBox_.Items.Clear();
                    categoryFilterComboBox_.Items.Add("Все категории");
                    foreach (var cat in categories)
                        categoryFilterComboBox_.Items.Add(cat);
                    categoryFilterComboBox_.SelectedIndex = 0;
                }
            }
            catch { }
        }

        public List<ProductItem> ApplyFilters()
        {
            try
            {
                var products = loader_.LoadProducts();
                if (products == null) return new List<ProductItem>();

                var filtered = products.AsEnumerable();

                string search = searchTextBox_.Text.Trim();
                if (!string.IsNullOrEmpty(search))
                    filtered = filtered.Where(p => p.Name.ToLower().Contains(search.ToLower()));

                if (categoryFilterComboBox_.SelectedIndex > 0)
                {
                    string category = categoryFilterComboBox_.SelectedItem.ToString();
                    filtered = filtered.Where(p => p.Category == category);
                }

                return filtered.ToList();
            }
            catch
            {
                return new List<ProductItem>();
            }
        }

        public void RefreshDisplay()
        {
            var filteredProducts = ApplyFilters();

            // Обновляем таблицу каталога
            productsForSaleGrid_.DataSource = null;
            productsForSaleGrid_.DataSource = filteredProducts;

            // Обновляем таблицу склада
            productsGrid_.DataSource = null;
            productsGrid_.DataSource = filteredProducts;

            // Обновляем счетчик
            productCountLabel_.Text = $"Всего товаров: {filteredProducts.Count}";

            // Принудительно обновляем отображение
            productsForSaleGrid_.Refresh();
            productsGrid_.Refresh();
        }
    }
}

