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
        // Загрузчик данных из базы PostgreSQL
        private PgComputerStoreLoader loader_;
        // Редактируемый товар
        private ProductItem product_;
        // Режим работы: true - редактирование, false - добавление
        private bool isEditMode_ = false;

        /// <summary>
        /// Конструктор формы редактирования товара
        /// </summary>
        /// <param name="product">Товар для редактирования (null - режим добавления)</param>
        /// <param name="loader">Загрузчик данных из БД</param>
        public ProductEditForm(ProductItem product, PgComputerStoreLoader loader)
        {
            InitializeComponent();
            loader_ = loader;

            if (product != null)
            {
                // Режим редактирования
                product_ = product;
                isEditMode_ = true;
                SetProduct(product); // Заполняем поля данными товара
                this.Text = "Редактирование товара";
            }
            else
            {
                // Режим добавления - создаем новый товар
                product_ = new ProductItem();
                this.Text = "Добавление товара";
            }
        }

        /// <summary>
        /// Заполняет поля формы данными товара
        /// </summary>
        /// <param name="product">Товар для отображения</param>
        private void SetProduct(ProductItem product)
        {
            NameTextBox.Text = product.Name;
            CategoryTextBox.Text = product.Category;
            PriceNumericUpDown.Value = product.Price;
            QuantityNumericUpDown.Value = product.Quantity;
            DescriptionTextBox.Text = product.Description ?? "";
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Сохранить"
        /// Проверяет данные и сохраняет товар в БД
        /// </summary>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей ввода
            string name = NameTextBox.Text.Trim();
            string category = CategoryTextBox.Text.Trim();
            decimal price = PriceNumericUpDown.Value;
            int quantity = (int)QuantityNumericUpDown.Value;
            string description = DescriptionTextBox.Text.Trim();

            // ========== ВАЛИДАЦИЯ ДАННЫХ ==========

            // Проверка: наименование обязательно
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Ошибка: наименование товара обязательно", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameTextBox.Focus(); // Устанавливаем курсор на поле
                return; // Прерываем выполнение
            }

            // Проверка: категория обязательна
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Выберите категорию", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CategoryTextBox.Focus();
                return;
            }

            // Проверка: цена должна быть положительной
            if (price <= 0)
            {
                MessageBox.Show("Цена должна быть больше нуля", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PriceNumericUpDown.Focus();
                return;
            }

            // Проверка: количество не может быть отрицательным
            if (quantity < 0)
            {
                MessageBox.Show("Количество не может быть отрицательным", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                QuantityNumericUpDown.Focus();
                return;
            }

            // ========== СОХРАНЕНИЕ ДАННЫХ ==========

            // Присваиваем значения объекту товара
            product_.Name = name;
            product_.Category = category;
            product_.Price = price;
            product_.Quantity = quantity;
            product_.Description = description;

            // Сохраняем в БД в зависимости от режима
            bool success = false;
            if (isEditMode_)
            {
                // Режим редактирования - обновляем существующий товар
                success = loader_.UpdateProduct(product_);
            }
            else
            {
                // Режим добавления - создаем новый товар
                success = loader_.AddProduct(product_);
            }

            // Проверяем результат сохранения
            if (success)
            {
                // Успешно - закрываем форму с положительным результатом
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Ошибка сохранения
                MessageBox.Show("Ошибка при сохранении товара", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена"
        /// Закрывает форму без сохранения
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
