using ComputerPartsShopLibrary.Date;
using ComputerPartsShopLibrary.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerPartsShop
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Database db = new Database();
            UserManager userManager = new UserManager(db);

            LoginForm loginForm = new LoginForm(userManager);

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Если логин прошел, открываем главную форму
                Application.Run(new MainForm(userManager));
            }
        }
    }
}
