using System;
using System.Data;
using System.Windows.Forms;
using ComputerStoreLib;
using ComputerStoreLib.Models;

namespace ComputerStore
{
    public partial class LoginForm : Form
    {
        // Загрузчик данных из базы PostgreSQL
        private PgComputerStoreLoader loader_;
        // Текущий авторизованный пользователь
        private User currentUser_;

        /// <summary>
        /// Конструктор формы авторизации
        /// </summary>
        /// <param name="loader">Загрузчик данных из БД</param>
        public LoginForm(PgComputerStoreLoader loader)
        {
            InitializeComponent();
            loader_ = loader; // Сохраняем ссылку на загрузчик
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Вход"
        /// </summary>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Получаем введенные данные и удаляем пробелы по краям
            string login = LoginTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прерываем выполнение
            }

            // Поиск пользователя в БД по логину
            var user = loader_.GetUserByLogin(login);

            // Проверка: существует ли пользователь и совпадает ли пароль
            if (user == null || user.Password != password)
            {
                // Если пользователь не найден или пароль неверный
                MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Очищаем поле пароля и устанавливаем фокус на него
                PasswordTextBox.Clear();
                PasswordTextBox.Focus();
                return; // Прерываем выполнение
            }

            // Авторизация успешна - сохраняем пользователя
            currentUser_ = user;

            // Показываем приветствие
            MessageBox.Show($"Добро пожаловать, {user.FullName ?? user.Login}!",
                          "Успешный вход", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Создаем и открываем главную форму, передавая загрузчик и текущего пользователя
            MainForm mainForm = new MainForm(loader_, currentUser_);
            mainForm.Show();

            // Скрываем текущую форму (но не закрываем, чтобы можно было вернуться)
            this.Hide();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Регистрация"
        /// Открывает форму регистрации нового пользователя
        /// </summary>
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(loader_);
            registerForm.ShowDialog(); // Модальное окно - ждем закрытия
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Отмена" / "Выход"
        /// Завершает работу приложения
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Полное завершение приложения
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// При закрытии формы завершаем приложение
        /// </summary>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
