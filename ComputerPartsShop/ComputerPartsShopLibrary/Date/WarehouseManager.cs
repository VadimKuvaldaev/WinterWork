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
        private List<ProductItem> stocks = new List<ProductItem>(); 
        public void AddProduct(ProductItem product) => stocks.Add(product); 
        public void RemoveProduct(int id) => stocks.RemoveAll(p => p.Id == id); 
        public void SellProduct(int id, int qty) => GetProductById(id).DecreaseQuantity(qty); 
        public List<ProductItem> GetProductsByCategory(string cat) => stocks.Where(p => p.Category == cat).ToList(); 
        public List<ProductItem> GetAllProducts() => stocks; 
        public ProductItem GetProductById(int id) => stocks.FirstOrDefault(p => p.Id == id); 
    }
}
