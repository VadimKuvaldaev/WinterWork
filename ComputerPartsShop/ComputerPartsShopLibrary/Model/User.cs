using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShopLibrary.Model
{
    public class User
    {
        private int id_;
        private string login_;
        private string passeord_;
        private Role role_;

        public User(int id, string login, string password, Role role)
        {
            id_ = id;
            login_ = login;
            passeord_ = password;
            role_ = role;
        }
        public int Id()
        {
            return id_;
        }
        public string Login()
        {
            return login_;
        }
        public string Passeord()
        {
            return passeord_;
        }
        public Role UserRole()
        {
            return role_;
        }
    }
}
