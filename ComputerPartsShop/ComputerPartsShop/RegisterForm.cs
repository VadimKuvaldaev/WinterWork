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
    public partial class RegisterForm : Form
    {
        private UserManager _userManager;

        public RegisterForm(UserManager userManager)
        {
            InitializeComponent();
            _userManager = userManager;

            // Настройка выбора ролей согласно Role (image_180c3f.png)
            NewRoleComboBox.Items.Add(Role.Admin);
            NewRoleComboBox.Items.Add(Role.Seller);
            NewRoleComboBox.SelectedIndex = 1; // По умолчанию Продавец

        }

        private void CreateButton_Click_1(object sender, EventArgs e)
        {
            // 1. Собираем данные из интерфейса
            string username = NewLoginTextBox.Text.Trim();
            string password = NewPasswordTextBox.Text.Trim();

            // Пытаемся распарсить роль из ComboBox (предположим, у тебя там Enum Role)
            if (!Enum.TryParse(NewRoleComboBox.SelectedItem.ToString(), out Role selectedRole))
            {
                MessageBox.Show("Пожалуйста, выберите корректную роль.");
                return;
            }

            // 2. Создаем объект User через твой конструктор
            // Передаем 0 для id, так как PostgreSQL (SERIAL) сам назначит индекс
            User newUser = new User(0, username, password, selectedRole);

            // 3. Отправляем на сохранение
            if (_userManager.Register(newUser))
            {
                MessageBox.Show("Регистрация прошла успешно!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось зарегистрировать пользователя. Возможно, логин занят.");
            }
        }
    }
}
