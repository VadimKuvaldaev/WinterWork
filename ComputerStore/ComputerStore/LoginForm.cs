using System;
using System.Data;
using System.Windows.Forms;
using ComputerStoreLib;
using ComputerStoreLib.Models;

namespace ComputerStore
{
    public partial class LoginForm : Form
    {
        private PgComputerStoreLoader loader_;
        private User currentUser_;

        public LoginForm(PgComputerStoreLoader loader)
        {
            InitializeComponent();
            loader_ = loader;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем пользователя
            var user = loader_.GetUserByLogin(login);

            if (user == null || user.Password != password)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Clear();
                PasswordTextBox.Focus();
                return;
            }

            currentUser_ = user;
            MessageBox.Show($"Добро пожаловать, {user.FullName ?? user.Login}!",
                          "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Открываем главную форму
            MainForm mainForm = new MainForm(loader_, currentUser_);
            mainForm.Show();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(loader_);
            registerForm.ShowDialog();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
