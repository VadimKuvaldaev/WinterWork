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
        private int id_;
        private string login_;
        private string password_;
        private Role role_;
        private string fullName_;
        private DateTime createdAt_;

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

        [DisplayName("Роль")]
        public Role Role
        {
            get { return role_; }
            set
            {
                role_ = value;
                OnPropertyChanged("Role");
                OnPropertyChanged("RoleDisplayName");
            }
        }

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

        public string RoleDisplayName
        {
            get { return Role == Role.Admin ? "Администратор" : "Продавец-консультант"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public User()
        {
            CreatedAt = DateTime.Now;
        }

        public User(string login, string password, Role role, string fullName = "")
        {
            Login = login;
            Password = password;
            Role = role;
            FullName = fullName;
            CreatedAt = DateTime.Now;
        }
    }
}
