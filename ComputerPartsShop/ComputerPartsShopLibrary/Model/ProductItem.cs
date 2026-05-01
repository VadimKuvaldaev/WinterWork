using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShopLibrary.Model
{
    public class ProductItem
    {
        private int id_;
        private string name_;
        private string category_;
        private decimal price_;
        private int quantity_;

        public int Id
        {
            get { return id_; }
            set { id_ = value; }
        }

        public string Name
        {
            get { return name_; }
            set { name_ = value; }
        }

        public string Category
        {
            get { return category_; }
            set { category_ = value; }
        }

        public decimal Price
        {
            get { return price_; }
            set { price_ = value; }
        }

        public int Quantity
        {
            get { return quantity_; }
            set { quantity_ = value; }
        }

        public void DecreaseQuantity(int amount)
        {
            if (quantity_ >= amount)
            {
                quantity_ -= amount;
            }
        }

        public void IncreaseQuantity(int amount)
        {
            quantity_ += amount;
        }
    }
}
