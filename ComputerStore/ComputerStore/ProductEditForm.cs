using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerStoreLib;
using ComputerStoreLib.Models;

namespace ComputerStore
{
    public partial class ProductEditForm : Form
    {
        private PgComputerStoreLoader loader_;
        private ProductItem product_;
        private bool isEditMode_ = false;

        public ProductEditForm(ProductItem product, PgComputerStoreLoader loader)
        {
            InitializeComponent();
            loader_ = loader;

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

        private void SetProduct(ProductItem product)
        {
            NameTextBox.Text = product.Name;
            CategoryTextBox.Text = product.Category;
            PriceNumericUpDown.Value = product.Price;
            QuantityNumericUpDown.Value = product.Quantity;
            DescriptionTextBox.Text = product.Description ?? "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string category = CategoryTextBox.Text.Trim();
            decimal price = PriceNumericUpDown.Value;
            int quantity = (int)QuantityNumericUpDown.Value;
            string description = DescriptionTextBox.Text.Trim();

            // Валидация
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Ошибка: наименование товара обязательно", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Выберите категорию", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CategoryTextBox.Focus();
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть больше нуля", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PriceNumericUpDown.Focus();
                return;
            }

            if (quantity < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QuantityNumericUpDown.Focus();
                return;
            }

            // Сохраняем
            product_.Name = name;
            product_.Category = category;
            product_.Price = price;
            product_.Quantity = quantity;
            product_.Description = description;

            bool success = false;
            if (isEditMode_)
            {
                success = loader_.UpdateProduct(product_);
            }
            else
            {
                success = loader_.AddProduct(product_);
            }

            if (success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении товара", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
