using System;
using System.Data;
using System.Windows.Forms;
using ComputerStoreLib;
using ComputerStoreLib.Models;

namespace ComputerStore
{
    public partial class RegisterForm : Form
    {
        // Загрузчик данных из базы PostgreSQL
        private PgComputerStoreLoader loader_;

        /// <summary>
        /// Конструктор формы регистрации
        /// </summary>
        /// <param name="loader">Загрузчик данных из БД</param>
        public RegisterForm(PgComputerStoreLoader loader)
        {
            InitializeComponent();
            loader_ = loader;

            // Заполняем выпадающий список ролей
            RoleComboBox.Items.Add("Администратор");
            RoleComboBox.Items.Add("Продавец-консультант");
            RoleComboBox.SelectedIndex = 1; // По умолчанию "Продавец"
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Создать"
        /// Проверяет данные и регистрирует нового пользователя
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // Получаем данные из полей ввода
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();
            string fullName = FullNameTextBox.Text.Trim();

            // ========== ВАЛИДАЦИЯ ДАННЫХ ==========

            // Проверка: все обязательные поля заполнены
            if (string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Заполните все поля", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: пароли совпадают
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTextBox.Clear();
                ConfirmPasswordTextBox.Clear();
                PasswordTextBox.Focus(); // Устанавливаем курсор на поле пароля
                return;
            }

            // Проверка: минимальная длина пароля (6 символов)
            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка: выбрана ли роль
            if (RoleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль пользователя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Определяем роль пользователя
            // Index 0 = Администратор, Index 1 = Продавец
            Role role = RoleComboBox.SelectedIndex == 0 ? Role.Admin : Role.Seller;

            // ========== ПРОВЕРКА СУЩЕСТВОВАНИЯ ПОЛЬЗОВАТЕЛЯ ==========

            // Проверяем, не занят ли логин
            var existingUser = loader_.GetUserByLogin(login);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTextBox.Clear();
                LoginTextBox.Focus();
                return;
            }

            // ========== СОХРАНЕНИЕ ПОЛЬЗОВАТЕЛЯ ==========

            // Создаем нового пользователя
            User newUser = new User(login, password, role, fullName);

            // Сохраняем в базу данных
            bool success = loader_.AddUser(newUser);

            // Проверяем результат сохранения
            if (success)
            {
                // Успешная регистрация
                MessageBox.Show("Пользователь успешно зарегистрирован", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Закрываем форму
            }
            else
            {
                // Ошибка при сохранении
                MessageBox.Show("Ошибка при регистрации пользователя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена"
        /// Закрывает форму без сохранения
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
