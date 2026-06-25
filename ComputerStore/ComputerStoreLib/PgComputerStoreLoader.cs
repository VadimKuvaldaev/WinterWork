using ComputerStoreLib.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerStoreLib
{
    public class PgComputerStoreLoader
    {
        private BindingList<User> users_ = new BindingList<User>();
        private BindingList<ProductItem> products_ = new BindingList<ProductItem>();
        private BindingList<Sale> sales_ = new BindingList<Sale>();

        private const string connectSetting = "Host=localhost;Username=postgres;Password=123456;Database=DBComputerStore";

        // ==================== ПОЛЬЗОВАТЕЛИ ====================

        public BindingList<User> LoadUsers()
        {
            try
            {
                users_.Clear();
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = "SELECT id, login, password, role, full_name, created_at FROM users";
                var cmd = new NpgsqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Role = (Role)Enum.Parse(typeof(Role), reader.GetString(3)),
                        FullName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        CreatedAt = reader.GetDateTime(5)
                    };
                    users_.Add(user);
                }
                reader.Close();
                con.Close();
                return users_;
            }
            catch (NpgsqlException exception)
            {
                System.Windows.MessageBox.Show($"Ошибка загрузки пользователей: {exception.Message}");
                return null;
            }
        }

        public bool AddUser(User user)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = @"INSERT INTO users (login, password, role, full_name, created_at) 
                           VALUES (@login, @password, @role, @full_name, NOW())";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@login", user.Login);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@role", user.Role.ToString());
                cmd.Parameters.AddWithValue("@full_name", user.FullName ?? "");

                int execute = cmd.ExecuteNonQuery();
                con.Close();

                if (execute > 0)
                {
                    users_.Add(user);
                    return true;
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления пользователя: {exception.Message}");
                return false;
            }
        }

        public bool AuthenticateUser(string login, string password)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = "SELECT id, login, password, role, full_name FROM users WHERE login = @login AND password = @password";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                var reader = cmd.ExecuteReader();
                bool exists = reader.HasRows;
                reader.Close();
                con.Close();
                return exists;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка авторизации: {exception.Message}");
                return false;
            }
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = "SELECT id, login, password, role, full_name, created_at FROM users WHERE login = @login";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@login", login);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetInt32(0),
                        Login = reader.GetString(1),
                        Password = reader.GetString(2),
                        Role = (Role)Enum.Parse(typeof(Role), reader.GetString(3)),
                        FullName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                        CreatedAt = reader.GetDateTime(5)
                    };
                    reader.Close();
                    con.Close();
                    return user;
                }
                reader.Close();
                con.Close();
                return null;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка получения пользователя: {exception.Message}");
                return null;
            }
        }

        // ==================== ТОВАРЫ ====================

        public BindingList<ProductItem> LoadProducts()
        {
            try
            {
                products_.Clear();
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = "SELECT id, name, category, price, quantity, description, added_at FROM products";
                var cmd = new NpgsqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductItem product = new ProductItem
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Category = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Quantity = reader.GetInt32(4),
                        Description = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        AddedAt = reader.GetDateTime(6)
                    };
                    products_.Add(product);
                }
                reader.Close();
                con.Close();
                return products_;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {exception.Message}");
                return null;
            }
        }

        public bool AddProduct(ProductItem product)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = @"INSERT INTO products (name, category, price, quantity, description, added_at) 
                           VALUES (@name, @category, @price, @quantity, @description, NOW())";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@category", product.Category);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@description", product.Description ?? "");

                int execute = cmd.ExecuteNonQuery();
                con.Close();

                if (execute > 0)
                {
                    // Обновляем список
                    LoadProducts();
                    return true;
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления товара: {exception.Message}");
                return false;
            }
        }

        public bool UpdateProduct(ProductItem product)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = @"UPDATE products SET name = @name, category = @category, 
                           price = @price, quantity = @quantity, description = @description 
                           WHERE id = @id";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@category", product.Category);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                cmd.Parameters.AddWithValue("@description", product.Description ?? "");

                int execute = cmd.ExecuteNonQuery();
                con.Close();

                if (execute > 0)
                {
                    LoadProducts();
                    return true;
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка обновления товара: {exception.Message}");
                return false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = "DELETE FROM products WHERE id = @id";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", productId);

                int execute = cmd.ExecuteNonQuery();
                con.Close();

                if (execute > 0)
                {
                    LoadProducts();
                    return true;
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка удаления товара: {exception.Message}");
                return false;
            }
        }

        public bool UpdateProductQuantity(int productId, int quantity)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = "UPDATE products SET quantity = @quantity WHERE id = @id";
                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.Parameters.AddWithValue("@quantity", quantity);

                int execute = cmd.ExecuteNonQuery();
                con.Close();

                if (execute > 0)
                {
                    LoadProducts();
                    return true;
                }
                return false;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка обновления количества: {exception.Message}");
                return false;
            }
        }

        // ==================== ПРОДАЖИ ====================

        public bool AddSale(Sale sale)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();

                // Добавляем продажу
                var sqlSale = @"INSERT INTO sales (user_id, user_name, sale_date, total_amount) 
                               VALUES (@user_id, @user_name, NOW(), @total_amount) RETURNING id";
                var cmdSale = new NpgsqlCommand(sqlSale, con);
                cmdSale.Parameters.AddWithValue("@user_id", sale.UserId);
                cmdSale.Parameters.AddWithValue("@user_name", sale.UserName ?? "");
                cmdSale.Parameters.AddWithValue("@total_amount", sale.TotalAmount);

                int saleId = Convert.ToInt32(cmdSale.ExecuteScalar());

                // Добавляем позиции продажи
                foreach (var item in sale.Items)
                {
                    var sqlItem = @"INSERT INTO sale_items (sale_id, product_id, product_name, category, price, quantity, total_price) 
                                   VALUES (@sale_id, @product_id, @product_name, @category, @price, @quantity, @total_price)";
                    var cmdItem = new NpgsqlCommand(sqlItem, con);
                    cmdItem.Parameters.AddWithValue("@sale_id", saleId);
                    cmdItem.Parameters.AddWithValue("@product_id", item.ProductId);
                    cmdItem.Parameters.AddWithValue("@product_name", item.ProductName);
                    cmdItem.Parameters.AddWithValue("@category", item.Category);
                    cmdItem.Parameters.AddWithValue("@price", item.Price);
                    cmdItem.Parameters.AddWithValue("@quantity", item.Quantity);
                    cmdItem.Parameters.AddWithValue("@total_price", item.TotalPrice);

                    cmdItem.ExecuteNonQuery();
                }

                con.Close();
                LoadSales();
                return true;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления продажи: {exception.Message}");
                return false;
            }
        }

        public BindingList<Sale> LoadSales()
        {
            try
            {
                sales_.Clear();
                var con = new NpgsqlConnection(connectSetting);
                con.Open();
                var sql = @"SELECT s.id, s.user_id, s.user_name, s.sale_date, s.total_amount,
                                   si.product_id, si.product_name, si.category, si.price, si.quantity, si.total_price
                            FROM sales s
                            LEFT JOIN sale_items si ON s.id = si.sale_id
                            ORDER BY s.sale_date DESC";
                var cmd = new NpgsqlCommand(sql, con);
                var reader = cmd.ExecuteReader();

                Dictionary<int, Sale> saleDict = new Dictionary<int, Sale>();

                while (reader.Read())
                {
                    int saleId = reader.GetInt32(0);

                    if (!saleDict.ContainsKey(saleId))
                    {
                        Sale sale = new Sale
                        {
                            Id = saleId,
                            UserId = reader.GetInt32(1),
                            UserName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            SaleDate = reader.GetDateTime(3),
                            TotalAmount = reader.GetDecimal(4)
                        };
                        saleDict.Add(saleId, sale);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        var sale = saleDict[saleId];
                        sale.Items.Add(new SaleItem
                        {
                            ProductId = reader.GetInt32(5),
                            ProductName = reader.GetString(6),
                            Category = reader.GetString(7),
                            Price = reader.GetDecimal(8),
                            Quantity = reader.GetInt32(9),
                            TotalPrice = reader.GetDecimal(10)
                        });
                    }
                }

                reader.Close();
                con.Close();

                sales_.Clear();
                foreach (var sale in saleDict.Values)
                {
                    sales_.Add(sale);
                }

                return sales_;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки продаж: {exception.Message}");
                return null;
            }
        }

        public BindingList<Sale> GetSalesByUser(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var result = new BindingList<Sale>();
                var con = new NpgsqlConnection(connectSetting);
                con.Open();

                string where = "s.user_id = @user_id";
                if (startDate.HasValue)
                    where += " AND s.sale_date >= @start_date";
                if (endDate.HasValue)
                    where += " AND s.sale_date <= @end_date";

                var sql = $@"SELECT s.id, s.user_id, s.user_name, s.sale_date, s.total_amount,
                                   si.product_id, si.product_name, si.category, si.price, si.quantity, si.total_price
                            FROM sales s
                            LEFT JOIN sale_items si ON s.id = si.sale_id
                            WHERE {where}
                            ORDER BY s.sale_date DESC";

                var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@user_id", userId);
                if (startDate.HasValue)
                    cmd.Parameters.AddWithValue("@start_date", startDate.Value);
                if (endDate.HasValue)
                    cmd.Parameters.AddWithValue("@end_date", endDate.Value);

                var reader = cmd.ExecuteReader();
                Dictionary<int, Sale> saleDict = new Dictionary<int, Sale>();

                while (reader.Read())
                {
                    int saleId = reader.GetInt32(0);

                    if (!saleDict.ContainsKey(saleId))
                    {
                        Sale sale = new Sale
                        {
                            Id = saleId,
                            UserId = reader.GetInt32(1),
                            UserName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            SaleDate = reader.GetDateTime(3),
                            TotalAmount = reader.GetDecimal(4)
                        };
                        saleDict.Add(saleId, sale);
                    }

                    if (!reader.IsDBNull(5))
                    {
                        var sale = saleDict[saleId];
                        sale.Items.Add(new SaleItem
                        {
                            ProductId = reader.GetInt32(5),
                            ProductName = reader.GetString(6),
                            Category = reader.GetString(7),
                            Price = reader.GetDecimal(8),
                            Quantity = reader.GetInt32(9),
                            TotalPrice = reader.GetDecimal(10)
                        });
                    }
                }

                reader.Close();
                con.Close();

                foreach (var sale in saleDict.Values)
                {
                    result.Add(sale);
                }

                return result;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки продаж пользователя: {exception.Message}");
                return null;
            }
        }

        public decimal GetTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var con = new NpgsqlConnection(connectSetting);
                con.Open();

                string where = "1=1";
                if (startDate.HasValue)
                    where += " AND sale_date >= @start_date";
                if (endDate.HasValue)
                    where += " AND sale_date <= @end_date";

                var sql = $"SELECT COALESCE(SUM(total_amount), 0) FROM sales WHERE {where}";
                var cmd = new NpgsqlCommand(sql, con);
                if (startDate.HasValue)
                    cmd.Parameters.AddWithValue("@start_date", startDate.Value);
                if (endDate.HasValue)
                    cmd.Parameters.AddWithValue("@end_date", endDate.Value);

                var result = cmd.ExecuteScalar();
                con.Close();
                return Convert.ToDecimal(result);
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка получения выручки: {exception.Message}");
                return 0;
            }
        }
    }
}