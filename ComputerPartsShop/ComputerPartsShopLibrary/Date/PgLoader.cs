using ComputerPartsShopLibrary.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShopLibrary.Date
{
    public class PgLoader
    {
        private string connectionString_ = "Host=localhost;Port=5432;Username=postgres;Password=твой_пароль;Database=DBComputerPartsShop";

        public List<ProductItem> GetSalesData()
        {
            List<ProductItem> sales = new List<ProductItem>();
            using (var con = new NpgsqlConnection(connectionString_))
            {
                con.Open();
                // Запрос для получения статистики продаж
                string sql = "SELECT p.name, SUM(si.quantity) FROM products p " +
                             "JOIN sales_items si ON p.id = si.productid GROUP BY p.name";

                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProductItem item = new ProductItem();
                        item.Name = reader.GetString(0);
                        item.Quantity = reader.GetInt32(1);
                        sales.Add(item);
                    }
                }
            }
            return sales;
        }
    }
}
