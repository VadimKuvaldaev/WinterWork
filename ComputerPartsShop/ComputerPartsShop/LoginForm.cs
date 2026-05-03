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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();
            User sessionUser = userManager.Login(tbLogin.Text, tbPassword.Text);

            if (sessionUser != null)
            {
                //MessageBox.Show($"Добро пожаловать, {sessionUser.Login}! Роль: {sessionUser.UserRole}");

                // Открываем основную форму (InventoryForm), которую мы сделали раньше
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide(); // Прячем окно логина
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void btnGoToRegister_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegisterForm regForm = new RegisterForm();
            regForm.ShowDialog();

            this.Show();
        }
    }
}
