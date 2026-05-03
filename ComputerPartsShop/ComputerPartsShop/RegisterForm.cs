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
        public RegisterForm()
        {
            InitializeComponent();
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // 1. Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(tbNewLogin.Text) || string.IsNullOrWhiteSpace(NewPasswordTextBox.Text))
            {
                MessageBox.Show("Заполните все поля"); 
        return;
            }

            // 2. Проверка выбора роли
            if (cbNewRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль пользователя"); 
        return;
            }

            // Обращаемся к менеджеру пользователей (как в твоей диаграмме классов)[cite: 1]
            bool isRegistered = userManager.Register(
                tbNewLogin.Text,
                tbNewPassword.Text,
                cbNewRole.SelectedItem.ToString()
            );

            if (isRegistered)
            {
                MessageBox.Show("Пользователь успешно зарегистрирован"); 
        this.Close();
            }
            else
            {
                // Ошибка: логин уже занят[cite: 1]
                MessageBox.Show("Пользователь с таким логином уже существует"); 
            }
            UserManager manager = new UserManager();
            bool isSuccess = manager.Register(tbNewLogin.Text, tbNewPassword.Text, cbNewRole.SelectedItem.ToString());

            if (isSuccess)
            {
                MessageBox.Show("Пользователь успешно зарегистрирован"); 
        
        
                 this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует"); 
            }
        }

       
    }
}
