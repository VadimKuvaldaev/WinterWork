using ComputerPartsShopLibrary.Date;
using ComputerPartsShopLibrary.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerPartsShopLibrary.Presenter
{
    public class UserManager
    {
        // Поле для работы с базой данных
        private readonly Database _database;

        // Свойство для хранения авторизованного пользователя (сессия)
        public User currentUser { get; private set; }

        public UserManager(Database database)
        {
            // Получаем экземпляр базы данных (обычно передается из Program.cs)
            _database = database;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        public User Login(string login, string password)
        {
            // Ищем пользователя в БД по логину
            User user = _database.GetUserByLogin(login);

            // Проверяем существование и совпадение пароля (используем нижний регистр свойств)
            if (user != null && user.Password == password)
            {
                currentUser = user; // Сохраняем пользователя в текущую сессию
                return user;
            }

            return null; // Если данные неверны
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        public bool Register(User newUser)
        {
            // 1. Проверяем, не занят ли логин
            if (_database.CheckUserExists(newUser.Login))
            {
                return false; // Логин уже существует
            }

            // 2. Пытаемся сохранить в базу данных
            return _database.SaveUser(newUser);
        }

        /// <summary>
        /// Выход из системы
        /// </summary>
        public void Logout()
        {
            currentUser = null;
        }
    }
}
