using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class ProductItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime AddedAt { get; set; }

        public decimal TotalValue => Price * Quantity;

        public ProductItem() { AddedAt = DateTime.Now; }

        public ProductItem(string name, string category, decimal price, int quantity, string description = "")
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            Description = description;
            AddedAt = DateTime.Now;
        }

        public void DecreaseQuantity(int amount)
        {
            if (Quantity >= amount) Quantity -= amount;
            else throw new InvalidOperationException($"Недостаточно товара. Доступно: {Quantity}");
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount > 0) Quantity += amount;
        }

        public override string ToString() => $"{Name} ({Category}) — {Price:C} — {Quantity} шт.";
    }
}