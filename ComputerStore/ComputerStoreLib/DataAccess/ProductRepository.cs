using ComputerStoreLib.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connString)
        {
            connectionString = connString;
        }

        public List<ProductItem> GetAllProducts()
        {
            var result = new List<ProductItem>();
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = "SELECT id, name, category, price, quantity, description, added_at FROM products";
                using (var cmd = new NpgsqlCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ProductItem
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Category = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            Quantity = reader.GetInt32(4),
                            Description = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            AddedAt = reader.GetDateTime(6)
                        });
                    }
                }
            }
            return result;
        }

        public bool AddProduct(ProductItem product)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = @"INSERT INTO products (name, category, price, quantity, description, added_at) 
                           VALUES (@name, @cat, @price, @qty, @desc, NOW())";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@cat", product.Category);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@qty", product.Quantity);
                    cmd.Parameters.AddWithValue("@desc", product.Description ?? "");
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateProduct(ProductItem product)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = @"UPDATE products SET name = @name, category = @cat, price = @price, 
                           quantity = @qty, description = @desc WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", product.Id);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@cat", product.Category);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@qty", product.Quantity);
                    cmd.Parameters.AddWithValue("@desc", product.Description ?? "");
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = "DELETE FROM products WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateQuantity(int productId, int quantity)
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                var sql = "UPDATE products SET quantity = @qty WHERE id = @id";
                using (var cmd = new NpgsqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
