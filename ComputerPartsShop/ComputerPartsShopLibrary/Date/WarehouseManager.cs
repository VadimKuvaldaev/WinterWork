using ComputerPartsShopLibrary.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShopLibrary.Date
{
    public class WarehouseManager
    {
        // Поле из диаграммы: - stocks: List<ProductItem> (private)
        private List<ProductItem> stocks = new List<ProductItem>();

        private string connectionString = "Host=localhost;Username=PostgreSQL 16;Password=123456;Database=DBComputerPartsShop";

        // + AddProduct(product: ProductItem): void
        public void AddProduct(ProductItem product)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string sql = "INSERT INTO products (name, category, price, quantity) VALUES (@n, @c, @p, @q)";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@n", product.Name);
                    cmd.Parameters.AddWithValue("@c", product.Category);
                    cmd.Parameters.AddWithValue("@p", product.Price);
                    cmd.Parameters.AddWithValue("@q", product.Quantity);
                    cmd.ExecuteNonQuery();
                }
            }
            stocks.Add(product);
        }

        // + RemoveProduct(id: int): void
        public void RemoveProduct(int id)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string sql = "DELETE FROM products WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            // Удаляем из локального списка тоже
            var item = stocks.FirstOrDefault(p => p.Id == id);
            if (item != null) stocks.Remove(item);
        }

        // + SellProduct(id: int, qty: int): void
        public void SellProduct(int id, int qty)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string sql = "UPDATE products SET quantity = quantity - @q WHERE id = @id AND quantity >= @q";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@q", qty);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            // Обновляем в локальном списке
            var item = stocks.FirstOrDefault(p => p.Id == id);
            if (item != null) item.DecreaseQuantity(qty);
        }

        // + GetProductsByCategory(cat: string): List<ProductItem>
        public List<ProductItem> GetProductsByCategory(string cat)
        {
            return stocks.Where(p => p.Category == cat).ToList();
        }

        // + GetAllProducts(): List<ProductItem>
        public List<ProductItem> GetAllProducts()
        {
            // Здесь лучше сначала подгрузить из базы, чтобы данные были свежие
            stocks.Clear();
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand("SELECT id, name, category, price, quantity FROM products", con))
                {
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        stocks.Add(new ProductItem
                        {
                            Id = r.GetInt32(0),
                            Name = r.GetString(1),
                            Category = r.GetString(2),
                            Price = r.GetDecimal(3),
                            Quantity = r.GetInt32(4)
                        });
                    }
                }
            }
            return stocks;
        }

        // + GetProductById(id: int): ProductItem
        public ProductItem GetProductById(int id)
        {
            return stocks.FirstOrDefault(p => p.Id == id);
        }
    }
}
