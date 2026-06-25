using System;
using System.Data;
using System.Windows.Forms;
using ComputerStoreLib;
using ComputerStoreLib.Models;

namespace ComputerStore
{
    public partial class RegisterForm : Form
    {
        private PgComputerStoreLoader loader_;

        public RegisterForm(PgComputerStoreLoader loader)
        {
            InitializeComponent();
            loader_ = loader;
            RoleComboBox.Items.Add("Администратор");
            RoleComboBox.Items.Add("Продавец-консультант");
            RoleComboBox.SelectedIndex = 1;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();
            string fullName = FullNameTextBox.Text.Trim();

            // Валидация
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Заполните все поля", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordTextBox.Clear();
                ConfirmPasswordTextBox.Clear();
                PasswordTextBox.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать не менее 6 символов", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RoleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите роль пользователя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Role role = RoleComboBox.SelectedIndex == 0 ? Role.Admin : Role.Seller;

            // Проверяем существование пользователя
            var existingUser = loader_.GetUserByLogin(login);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginTextBox.Clear();
                LoginTextBox.Focus();
                return;
            }

            // Добавляем пользователя
            User newUser = new User(login, password, role, fullName);
            bool success = loader_.AddUser(newUser);

            if (success)
            {
                MessageBox.Show("Пользователь успешно зарегистрирован", "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации пользователя", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
