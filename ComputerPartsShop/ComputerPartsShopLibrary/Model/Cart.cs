using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShopLibrary.Model
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>(); 

        public void AddItem(ProductItem product, int quantity) 
        {
            var existing = items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existing != null) existing.Quantity += quantity;
            else items.Add(new CartItem(product, quantity));
        }

        public void RemoveItem(int productId) => items.RemoveAll(i => i.Product.Id == productId); 
        public void Clear() => items.Clear();
        public decimal GetTotalSum() => items.Sum(i => i.TotalPrice);

        public List<CartItem> GetItems() => items;
    }       
}


