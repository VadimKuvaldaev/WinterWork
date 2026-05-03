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
    public partial class LoginForm : Form
    {
        private UserManager _userManager;

        public LoginForm(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;

            // Настройка полей ввода пароля
            PasswordTextBox.PasswordChar = '●';
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Закрытие приложения при отмене
            this.DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        private void GoToRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(_userManager);

            // 2. Скрываем текущую форму авторизации (необязательно, но так чище)
            this.Hide();

            // 3. Открываем форму регистрации модально
            // ShowDialog останавливает выполнение кода здесь, пока пользователь не закроет RegisterForm
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                // Если регистрация прошла успешно, можно сразу подставить логин в поле ввода
                // LoginTextBox.Text = registerForm.NewUsername; 
            }

            // 4. Снова показываем форму авторизации после закрытия окна регистрации
            this.Show();
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            string username = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            // Валидация пустых полей
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Попытка входа через UserManager согласно схеме
            if (_userManager.Login(username, password) != null)
            {
                // Устанавливаем результат и закрываем форму
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Clear();
            }
        }
    }
}
