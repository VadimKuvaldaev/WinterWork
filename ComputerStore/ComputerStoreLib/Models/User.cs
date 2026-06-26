using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class User : INotifyPropertyChanged
    {
        // Приватные поля для хранения данных
        private int id_;
        private string login_;
        private string password_;
        private Role role_;
        private string fullName_;
        private DateTime createdAt_;

        /// <summary>
        /// Уникальный идентификатор пользователя
        /// </summary>
        [DisplayName("ID")]
        public int Id
        {
            get { return id_; }
            set
            {
                id_ = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Логин пользователя (уникальный)
        /// </summary>
        [DisplayName("Логин")]
        public string Login
        {
            get { return login_; }
            set
            {
                login_ = value;
                OnPropertyChanged("Login");
            }
        }

        /// <summary>
        /// Пароль пользователя (в реальном проекте должен храниться в зашифрованном виде)
        /// </summary>
        [DisplayName("Пароль")]
        public string Password
        {
            get { return password_; }
            set
            {
                password_ = value;
                OnPropertyChanged("Password");
            }
        }

        /// <summary>
        /// Роль пользователя (Admin или Seller)
        /// </summary>
        [DisplayName("Роль")]
        public Role Role
        {
            get { return role_; }
            set
            {
                role_ = value;
                OnPropertyChanged("Role");
                OnPropertyChanged("RoleDisplayName"); // Обновляем отображаемое имя роли
            }
        }

        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        [DisplayName("ФИО")]
        public string FullName
        {
            get { return fullName_; }
            set
            {
                fullName_ = value;
                OnPropertyChanged("FullName");
            }
        }

        /// <summary>
        /// Дата создания учетной записи
        /// </summary>
        [DisplayName("Дата создания")]
        public DateTime CreatedAt
        {
            get { return createdAt_; }
            set
            {
                createdAt_ = value;
                OnPropertyChanged("CreatedAt");
            }
        }

        /// <summary>
        /// Отображаемое имя роли на русском языке
        /// Вычисляемое свойство - только для чтения
        /// </summary>
        public string RoleDisplayName
        {
            get { return Role == Role.Admin ? "Администратор" : "Продавец-консультант"; }
        }

        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызов события изменения свойства
        /// </summary>
        /// <param name="prop">Имя измененного свойства</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public User()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <param name="role">Роль</param>
        /// <param name="fullName">Полное имя (необязательно)</param>
        public User(string login, string password, Role role, string fullName = "")
        {
            Login = login;
            Password = password;
            Role = role;
            FullName = fullName;
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Строковое представление пользователя
        /// </summary>
        /// <returns>ФИО (Логин) - Роль</returns>
        public override string ToString()
        {
            return $"{FullName ?? Login} ({Login}) - {RoleDisplayName}";
        }

        /// <summary>
        /// Проверка, является ли пользователь администратором
        /// </summary>
        /// <returns>True - администратор, False - продавец</returns>
        public bool IsAdmin()
        {
            return Role == Role.Admin;
        }

        /// <summary>
        /// Проверка, является ли пользователь продавцом
        /// </summary>
        /// <returns>True - продавец, False - администратор</returns>
        public bool IsSeller()
        {
            return Role == Role.Seller;
        }
    }
}
