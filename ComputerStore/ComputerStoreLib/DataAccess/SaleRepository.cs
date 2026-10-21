using ComputerStoreLib.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib
{
    public class SaleRepository
    {
        private readonly string connectionString;

        public SaleRepository(string connString)
        {
            connectionString = connString;
        }

        public bool AddSale(Sale sale)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                // Добавляем продажу (без user_name!)
                var sqlSale = @"INSERT INTO sales (user_id, sale_date, total_amount) 
                               VALUES (@user_id, NOW(), @total) RETURNING id";
                int saleId;
                using (var cmdSale = new NpgsqlCommand(sqlSale, con))
                {
                    cmdSale.Parameters.AddWithValue("@user_id", sale.UserId);
                    cmdSale.Parameters.AddWithValue("@total", sale.TotalAmount);
                    saleId = Convert.ToInt32(cmdSale.ExecuteScalar());
                }

                // Добавляем позиции
                foreach (var item in sale.Items)
                {
                    var sqlItem = @"INSERT INTO sale_items (sale_id, product_id, product_name, category, price, quantity, total_price) 
                                   VALUES (@sale_id, @pid, @pname, @cat, @price, @qty, @total)";
                    using (var cmdItem = new NpgsqlCommand(sqlItem, con))
                    {
                        cmdItem.Parameters.AddWithValue("@sale_id", saleId);
                        cmdItem.Parameters.AddWithValue("@pid", item.ProductId);
                        cmdItem.Parameters.AddWithValue("@pname", item.ProductName);
                        cmdItem.Parameters.AddWithValue("@cat", item.Category);
                        cmdItem.Parameters.AddWithValue("@price", item.Price);
                        cmdItem.Parameters.AddWithValue("@qty", item.Quantity);
                        cmdItem.Parameters.AddWithValue("@total", item.TotalPrice);
                        cmdItem.ExecuteNonQuery();
                    }
                }
                return true;
            }
        }

        public List<Sale> GetSalesByPeriod(DateTime startDate, DateTime endDate)
        {
            var result = new List<Sale>();
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = @"SELECT s.id, s.user_id, s.sale_date, s.total_amount,
                                   si.product_id, si.product_name, si.category, si.price, si.quantity, si.total_price
                            FROM sales s
                            LEFT JOIN sale_items si ON s.id = si.sale_id
                            WHERE s.sale_date >= @start AND s.sale_date <= @end
                            ORDER BY s.sale_date DESC";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@start", startDate);
                    cmd.Parameters.AddWithValue("@end", endDate);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dict = new Dictionary<int, Sale>();
                        while (reader.Read())
                        {
                            int saleId = reader.GetInt32(0);
                            if (!dict.ContainsKey(saleId))
                            {
                                dict[saleId] = new Sale
                                {
                                    Id = saleId,
                                    UserId = reader.GetInt32(1),
                                    SaleDate = reader.GetDateTime(2),
                                    TotalAmount = reader.GetDecimal(3)
                                };
                            }
                            if (!reader.IsDBNull(4))
                            {
                                dict[saleId].Items.Add(new SaleItem
                                {
                                    ProductId = reader.GetInt32(4),
                                    ProductName = reader.GetString(5),
                                    Category = reader.GetString(6),
                                    Price = reader.GetDecimal(7),
                                    Quantity = reader.GetInt32(8),
                                    TotalPrice = reader.GetDecimal(9)
                                });
                            }
                        }
                        result.AddRange(dict.Values);
                    }
                }
            }
            return result;
        }

        public decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = "SELECT COALESCE(SUM(total_amount), 0) FROM sales WHERE sale_date >= @start AND sale_date <= @end";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@start", startDate);
                    cmd.Parameters.AddWithValue("@end", endDate);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }
    }
}
