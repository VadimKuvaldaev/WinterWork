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
        private string connectionString = "Host=localhost;Username=PostgreSQL 16;Password=123456;Database=DBComputerPartsShop";

        // Метод для входа в систему
        public User Login(string login, string password)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    // Ищем пользователя по логину и паролю
                    string sql = "SELECT id, login, password, role FROM users WHERE login = @l AND password = @p";

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@l", login);
                        cmd.Parameters.AddWithValue("@p", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Если нашли, создаем объект User из твоей модели
                                int id = reader.GetInt32(0);
                                string userLogin = reader.GetString(1);
                                string userPass = reader.GetString(2);

                                // Парсим роль из строки (Admin/Seller) в Enum Role
                                Role userRole = (Role)Enum.Parse(typeof(Role), reader.GetString(3));

                                return new User(id, userLogin, userPass, userRole);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации: " + ex.Message);
            }

            return null; // Если не нашли или ошибка
        }
    }
}
