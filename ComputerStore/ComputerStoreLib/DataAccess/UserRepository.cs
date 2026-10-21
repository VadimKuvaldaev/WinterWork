using ComputerStoreLib.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connString)
        {
            connectionString = connString;
        }

        public User GetUserByLogin(string login)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = "SELECT id, login, password, role, full_name, created_at FROM users WHERE login = @login";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = (Role)Enum.Parse(typeof(Role), reader.GetString(3)),
                                FullName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                CreatedAt = reader.GetDateTime(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool AddUser(User user)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = @"INSERT INTO users (login, password, role, full_name, created_at) 
                           VALUES (@login, @pass, @role, @name, NOW())";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@login", user.Login);
                    cmd.Parameters.AddWithValue("@pass", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role.ToString());
                    cmd.Parameters.AddWithValue("@name", user.FullName ?? "");
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool AuthenticateUser(string login, string password)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = "SELECT id FROM users WHERE login = @login AND password = @pass";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@pass", password);
                    return cmd.ExecuteScalar() != null;
                }
            }
        }
    }
}