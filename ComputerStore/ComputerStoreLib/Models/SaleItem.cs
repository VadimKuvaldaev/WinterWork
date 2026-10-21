using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class SaleItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public SaleItem() { }

        public SaleItem(int productId, string productName, string category, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Price = price;
            Quantity = quantity;
            TotalPrice = price * quantity;
        }

        public override string ToString() => $"{ProductName} — {Quantity} шт. x {Price:C} = {TotalPrice:C}";
    }
}