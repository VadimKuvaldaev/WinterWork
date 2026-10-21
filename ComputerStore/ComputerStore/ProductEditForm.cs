using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ComputerStoreLib;
using ComputerStoreLib.Models;

namespace ComputerStore
{
    public partial class ProductEditForm : Form
    {
        private ProductRepository productRepo_;
        private ProductItem product_;
        private bool isEditMode_ = false;

        public ProductEditForm(ProductItem product, string connString)
        {
            InitializeComponent();
            productRepo_ = new ProductRepository(connString);

            LoadCategories();

            if (product != null)
            {
                product_ = product;
                isEditMode_ = true;
                SetProduct(product);
                this.Text = "Редактирование товара";
            }
            else
            {
                product_ = new ProductItem();
                this.Text = "Добавление товара";
            }
        }

        private void LoadCategories()
        {
            var products = productRepo_.GetAllProducts();
            var categories = products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();

            CategoryComboBox.Items.Clear();
            CategoryComboBox.Items.AddRange(categories.ToArray());
        }

        private void SetProduct(ProductItem product)
        {
            NameTextBox.Text = product.Name;

            if (CategoryComboBox.Items.Contains(product.Category))
            {
                CategoryComboBox.SelectedItem = product.Category;
            }
            else if (!string.IsNullOrEmpty(product.Category))
            {
                CategoryComboBox.Items.Add(product.Category);
                CategoryComboBox.SelectedItem = product.Category;
            }

            PriceNumericUpDown.Value = product.Price;
            QuantityNumericUpDown.Value = product.Quantity;
            DescriptionTextBox.Text = product.Description ?? "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string category = CategoryComboBox.SelectedItem?.ToString() ?? "";
            decimal price = PriceNumericUpDown.Value;
            int quantity = (int)QuantityNumericUpDown.Value;
            string description = DescriptionTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Ошибка: наименование товара обязательно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Выберите категорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CategoryComboBox.Focus();
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть больше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PriceNumericUpDown.Focus();
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QuantityNumericUpDown.Focus();
                return;
            }

            product_.Name = name;
            product_.Category = category;
            product_.Price = price;
            product_.Quantity = quantity;
            product_.Description = description;

            bool success = isEditMode_
                ? productRepo_.UpdateProduct(product_)
                : productRepo_.AddProduct(product_);

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении товара", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}