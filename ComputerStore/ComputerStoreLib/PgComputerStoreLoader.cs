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
        // Кэши данных для быстрого доступа
        private BindingList<User> users_ = new BindingList<User>();
        private BindingList<ProductItem> products_ = new BindingList<ProductItem>();
        private BindingList<Sale> sales_ = new BindingList<Sale>();

        // Строка подключения к базе данных
        private const string connectSetting = "Host=localhost;Username=postgres;Password=123456;Database=DBComputerStore";

        // ============================================================
        // ПОЛЬЗОВАТЕЛИ
        // ============================================================

        /// <summary>
        /// Загрузка всех пользователей из базы данных
        /// </summary>
        /// <returns>Список пользователей или null при ошибке</returns>
        public BindingList<User> LoadUsers()
        {
            try
            {
                users_.Clear();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "SELECT id, login, password, role, full_name, created_at FROM users";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
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
                    }
                }
                return users_;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Добавление нового пользователя в базу данных
        /// </summary>
        /// <param name="user">Объект пользователя</param>
        /// <returns>True - успешно, False - ошибка</returns>
        public bool AddUser(User user)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"INSERT INTO users (login, password, role, full_name, created_at) 
                               VALUES (@login, @password, @role, @full_name, NOW())";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@login", user.Login);
                        cmd.Parameters.AddWithValue("@password", user.Password);
                        cmd.Parameters.AddWithValue("@role", user.Role.ToString());
                        cmd.Parameters.AddWithValue("@full_name", user.FullName ?? "");

                        int execute = cmd.ExecuteNonQuery();
                        if (execute > 0)
                        {
                            users_.Add(user);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления пользователя: {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// Проверка авторизации пользователя
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>True - авторизация успешна, False - ошибка</returns>
        public bool AuthenticateUser(string login, string password)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "SELECT id FROM users WHERE login = @login AND password = @password";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        var result = cmd.ExecuteScalar();
                        return result != null;
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка авторизации: {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Объект User или null</returns>
        public User GetUserByLogin(string login)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
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
                            return null;
                        }
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка получения пользователя: {exception.Message}");
                return null;
            }
        }

        // ============================================================
        // ТОВАРЫ
        // ============================================================

        /// <summary>
        /// Загрузка всех товаров из базы данных
        /// </summary>
        /// <returns>Список товаров или null при ошибке</returns>
        public BindingList<ProductItem> LoadProducts()
        {
            try
            {
                products_.Clear();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "SELECT id, name, category, price, quantity, description, added_at FROM products";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
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
                    }
                }
                return products_;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Добавление нового товара в базу данных
        /// </summary>
        /// <param name="product">Объект товара</param>
        /// <returns>True - успешно, False - ошибка</returns>
        public bool AddProduct(ProductItem product)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"INSERT INTO products (name, category, price, quantity, description, added_at) 
                               VALUES (@name, @category, @price, @quantity, @description, NOW())";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@category", product.Category);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                        cmd.Parameters.AddWithValue("@description", product.Description ?? "");

                        int execute = cmd.ExecuteNonQuery();
                        if (execute > 0)
                        {
                            LoadProducts(); // Обновляем кэш
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления товара: {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// Обновление информации о товаре
        /// </summary>
        /// <param name="product">Объект товара с обновленными данными</param>
        /// <returns>True - успешно, False - ошибка</returns>
        public bool UpdateProduct(ProductItem product)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"UPDATE products SET name = @name, category = @category, 
                               price = @price, quantity = @quantity, description = @description 
                               WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", product.Id);
                        cmd.Parameters.AddWithValue("@name", product.Name);
                        cmd.Parameters.AddWithValue("@category", product.Category);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                        cmd.Parameters.AddWithValue("@description", product.Description ?? "");

                        int execute = cmd.ExecuteNonQuery();
                        if (execute > 0)
                        {
                            LoadProducts(); // Обновляем кэш
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка обновления товара: {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// Удаление товара из базы данных
        /// </summary>
        /// <param name="productId">ID товара</param>
        /// <returns>True - успешно, False - ошибка</returns>
        public bool DeleteProduct(int productId)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "DELETE FROM products WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);

                        int execute = cmd.ExecuteNonQuery();
                        if (execute > 0)
                        {
                            LoadProducts(); // Обновляем кэш
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка удаления товара: {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// Обновление количества товара на складе
        /// </summary>
        /// <param name="productId">ID товара</param>
        /// <param name="quantity">Новое количество</param>
        /// <returns>True - успешно, False - ошибка</returns>
        public bool UpdateProductQuantity(int productId, int quantity)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = "UPDATE products SET quantity = @quantity WHERE id = @id";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        cmd.Parameters.AddWithValue("@quantity", quantity);

                        int execute = cmd.ExecuteNonQuery();
                        if (execute > 0)
                        {
                            LoadProducts(); // Обновляем кэш
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка обновления количества: {exception.Message}");
                return false;
            }
        }

        // ============================================================
        // ПРОДАЖИ
        // ============================================================

        /// <summary>
        /// Добавление новой продажи в базу данных
        /// </summary>
        /// <param name="sale">Объект продажи</param>
        /// <returns>True - успешно, False - ошибка</returns>
        public bool AddSale(Sale sale)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();

                    // Добавляем продажу
                    var sqlSale = @"INSERT INTO sales (user_id, user_name, sale_date, total_amount) 
                                   VALUES (@user_id, @user_name, NOW(), @total_amount) RETURNING id";
                    using (var cmdSale = new NpgsqlCommand(sqlSale, con))
                    {
                        cmdSale.Parameters.AddWithValue("@user_id", sale.UserId);
                        cmdSale.Parameters.AddWithValue("@user_name", sale.UserName ?? "");
                        cmdSale.Parameters.AddWithValue("@total_amount", sale.TotalAmount);

                        int saleId = Convert.ToInt32(cmdSale.ExecuteScalar());

                        // Добавляем позиции продажи
                        foreach (var item in sale.Items)
                        {
                            var sqlItem = @"INSERT INTO sale_items (sale_id, product_id, product_name, category, price, quantity, total_price) 
                                           VALUES (@sale_id, @product_id, @product_name, @category, @price, @quantity, @total_price)";
                            using (var cmdItem = new NpgsqlCommand(sqlItem, con))
                            {
                                cmdItem.Parameters.AddWithValue("@sale_id", saleId);
                                cmdItem.Parameters.AddWithValue("@product_id", item.ProductId);
                                cmdItem.Parameters.AddWithValue("@product_name", item.ProductName);
                                cmdItem.Parameters.AddWithValue("@category", item.Category);
                                cmdItem.Parameters.AddWithValue("@price", item.Price);
                                cmdItem.Parameters.AddWithValue("@quantity", item.Quantity);
                                cmdItem.Parameters.AddWithValue("@total_price", item.TotalPrice);

                                cmdItem.ExecuteNonQuery();
                            }
                        }
                    }

                    LoadSales(); // Обновляем кэш
                    return true;
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка добавления продажи: {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// Загрузка всех продаж из базы данных
        /// </summary>
        /// <returns>Список продаж или null при ошибке</returns>
        public BindingList<Sale> LoadSales()
        {
            try
            {
                sales_.Clear();
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();
                    var sql = @"SELECT s.id, s.user_id, s.user_name, s.sale_date, s.total_amount,
                                       si.product_id, si.product_name, si.category, si.price, si.quantity, si.total_price
                                FROM sales s
                                LEFT JOIN sale_items si ON s.id = si.sale_id
                                ORDER BY s.sale_date DESC";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    using (var reader = cmd.ExecuteReader())
                    {
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

                        sales_.Clear();
                        foreach (var sale in saleDict.Values)
                        {
                            sales_.Add(sale);
                        }
                    }
                }
                return sales_;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки продаж: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Получение продаж конкретного пользователя за период
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="startDate">Начальная дата (необязательно)</param>
        /// <param name="endDate">Конечная дата (необязательно)</param>
        /// <returns>Список продаж или null при ошибке</returns>
        public BindingList<Sale> GetSalesByUser(int userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var result = new BindingList<Sale>();
                using (var con = new NpgsqlConnection(connectSetting))
                {
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

                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        if (startDate.HasValue)
                            cmd.Parameters.AddWithValue("@start_date", startDate.Value);
                        if (endDate.HasValue)
                            cmd.Parameters.AddWithValue("@end_date", endDate.Value);

                        using (var reader = cmd.ExecuteReader())
                        {
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

                            foreach (var sale in saleDict.Values)
                            {
                                result.Add(sale);
                            }
                        }
                    }
                }
                return result;
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка загрузки продаж пользователя: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// Получение общей выручки за период
        /// </summary>
        /// <param name="startDate">Начальная дата (необязательно)</param>
        /// <param name="endDate">Конечная дата (необязательно)</param>
        /// <returns>Сумма выручки</returns>
        public decimal GetTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectSetting))
                {
                    con.Open();

                    string where = "1=1";
                    if (startDate.HasValue)
                        where += " AND sale_date >= @start_date";
                    if (endDate.HasValue)
                        where += " AND sale_date <= @end_date";

                    var sql = $"SELECT COALESCE(SUM(total_amount), 0) FROM sales WHERE {where}";
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        if (startDate.HasValue)
                            cmd.Parameters.AddWithValue("@start_date", startDate.Value);
                        if (endDate.HasValue)
                            cmd.Parameters.AddWithValue("@end_date", endDate.Value);

                        return Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch (NpgsqlException exception)
            {
                MessageBox.Show($"Ошибка получения выручки: {exception.Message}");
                return 0;
            }
        }
    }
}