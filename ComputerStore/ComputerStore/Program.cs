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

            // Строка подключения к базе данных
            // Убедись, что пароль и название БД совпадают с твоими!
            string connString = "Host=localhost;Username=postgres;Password=123456;Database=DBComputerStore";

            // Запускаем форму входа, передавая ей строку подключения
            LoginForm loginForm = new LoginForm(connString);
            Application.Run(loginForm);
        }
    }
}
