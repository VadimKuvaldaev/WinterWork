using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ComputerPartsShopLibrary.Model
{
    public class User : INotifyPropertyChanged
    {
        private int id_;
        private string login_;
        private string password_;
        private Role role_;

        public User(int id, string login, string password, Role role)
        {
            id_ = id;
            login_ = login;
            password_ = password;
            role_ = role;
        }
        public int Id
        {
            get { return id_; }
            set
            {
                id_ = value;
                OnPropertyChanged("id");
            }
        }
        public string Login
        {
            get { return login_; }
            set
            {
                login_ = value;
                OnPropertyChanged("login");
            }
        }
        public string Password
        {
            get { return password_; }
            set
            {
                password_ = value;
                OnPropertyChanged("password");
            }
        }
        public Role UserRole
        {
            get { return role_; }
            set
            {
                role_ = value;
                OnPropertyChanged("role");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
