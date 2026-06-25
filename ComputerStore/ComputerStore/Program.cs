using ComputerStore;
using ComputerStoreLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerStore
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
            Application.SetCompatibleTextRenderingDefault(false);

            // Создаем загрузчик базы данных
            PgComputerStoreLoader loader = new PgComputerStoreLoader();

            // Запускаем форму входа
            LoginForm loginForm = new LoginForm(loader);
            Application.Run(loginForm);
        }
    }
}
