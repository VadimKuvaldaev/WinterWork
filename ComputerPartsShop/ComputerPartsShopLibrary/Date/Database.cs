using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ComputerPartsShopLibrary.Date
{
    public class Database 
    {
        private string connectionString_ = "Host=localhost;Username=PostgreSQL 16;Password=123456;Database=DBComputerPartsShop";

        public void ExecuteQuery(string sql)
        {
            try
            {
                using (var con = new NpgsqlConnection(connectionString_))
                {
                    con.Open();
                    using (var cmd = new NpgsqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message);
            }
        }
    }
}
