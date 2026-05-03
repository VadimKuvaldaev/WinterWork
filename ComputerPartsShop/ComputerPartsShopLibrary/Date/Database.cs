using ComputerPartsShopLibrary.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerPartsShopLibrary.Date
{
    public class Database
    {
        private BindingList<ProductItem> productList = new BindingList<ProductItem>();
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=123456;Database=DBComputerPartsShop";
        private BindingList<User> userList = new BindingList<User>();

        public BindingList<ProductItem> LoadAll()
        {
            try
            {
                productList.Clear(); // Очищаем перед загрузкой, чтобы не дублировать
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "SELECT id, name, quantity, price, category FROM products";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductItem item = new ProductItem
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Category = reader.GetString(2),
                                    Price = reader.GetDecimal(3),
                                    Quantity = reader.GetInt32(4),
                                };
                                productList.Add(item);
                            }
                        }
                    }
                }
                return productList;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
                return null;
            }
        }

        public bool DeleteProduct(string productName)
        {
            try
            {
                bool isDeleted = false;
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "DELETE FROM products WHERE name = @name";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", productName);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            isDeleted = true;
                            // Синхронизируем локальный список
                            for (int i = 0; i < productList.Count; i++)
                            {
                                if (productList[i].Name == productName)
                                {
                                    productList.RemoveAt(i);
                                    i--;
                                }
                            }
                        }
                    }
                }
                return isDeleted;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка удаления: {ex.Message}");
                return false;
            }
        }

        public bool AddProduct(ProductItem item)
        {
            try
            {
                bool isAdded = false;
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO products (name, quantity) VALUES (@name, @quantity, @price, @category)";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", item.Name);
                        command.Parameters.AddWithValue("@quantity", item.Quantity);
                        command.Parameters.AddWithValue("@price", item.Price);
                        command.Parameters.AddWithValue("@category", item.Category);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isAdded = true;
                            productList.Add(item);
                        }
                    }
                }
                return isAdded;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка добавления: {ex.Message}");
                return false;
            }
        }

        public bool UpdateProduct(ProductItem item)
        {
            try
            {
                bool isUpdated = false;
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO products (name, quantity) VALUES (@name, @quantity, @price, @category)";
                    using (var command = new NpgsqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", item.Name);
                        command.Parameters.AddWithValue("@quantity", item.Quantity);
                        command.Parameters.AddWithValue("@price", item.Price);
                        command.Parameters.AddWithValue("@category", item.Category);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isUpdated = true;
                            for (int i = 0; i < productList.Count; i++)
                            {
                                if (productList[i].Name == item.Name)
                                {
                                    productList[i] = item;
                                    break;
                                }
                            }
                        }
                    }
                }
                return isUpdated;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка обновления: {ex.Message}");
                return false;
            }
        }


        //ПОЛЬЗОВАТЕЛИ
        public BindingList<User> LoadAllUsers()
        {
            try
            {
                userList.Clear();
                using (var con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    var sql = "SELECT id, login, password, role FROM users";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Преобразуем строку из БД в Enum Role
                                Enum.TryParse(reader.GetString(3), out Role userRole);

                                // Используем твой конструктор: public User(int id, string login, string password, Role role)
                                User user = new User(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    userRole
                                );
                                userList.Add(user);
                            }
                        }
                    }
                }
                return userList;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}");
                return null;
            }
        }

        // 2. Добавление (Регистрация) нового пользователя
        public bool AddUser(User user)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    var sql = "INSERT INTO users (login, password, role) VALUES (@login, @password, @role)";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@login", user.Login);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@role", user.UserRole.ToString());

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            userList.Add(user);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
                return false;
            }
        }

        // 3. Метод для авторизации (проверка логина и пароля)
        public User Authenticate(string login, string password)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    var sql = "SELECT id, login, password, role FROM users WHERE login = @l AND password = @p";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@l", login);
                        cmd.Parameters.AddWithValue("@p", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Enum.TryParse(reader.GetString(3), out Role r);
                                return new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), r);
                            }
                        }
                    }
                }
                return null; // Пользователь не найден или пароль неверный
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Ошибка входа: {ex.Message}");
                return null;
            }
        }
    }
}
