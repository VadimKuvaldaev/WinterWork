using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; } = new List<CartItem>();
        public decimal TotalSum => Items.Sum(x => x.TotalPrice);
        public int Count => Items.Count;
        public bool IsEmpty => Items.Count == 0;

        public void AddItem(ProductItem product, int quantity)
        {
            var existing = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existing != null) existing.Quantity += quantity;
            else Items.Add(new CartItem(product, quantity));
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null) Items.Remove(item);
        }

        public void Clear() => Items.Clear();
    }
}