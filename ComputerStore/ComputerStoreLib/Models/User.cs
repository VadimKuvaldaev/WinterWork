using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }

        public string RoleDisplayName => Role == Role.Admin ? "Администратор" : "Продавец-консультант";

        public User() { CreatedAt = DateTime.Now; }

        public User(string login, string password, Role role, string fullName = "")
        {
            Login = login;
            Password = password;
            Role = role;
            FullName = fullName;
            CreatedAt = DateTime.Now;
        }

        public bool IsAdmin() => Role == Role.Admin;
        public bool IsSeller() => Role == Role.Seller;

        public override string ToString() => $"{FullName ?? Login} ({Login}) — {RoleDisplayName}";
    }
}