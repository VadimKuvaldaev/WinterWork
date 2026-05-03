using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public ProductItem(int id, string name, string category, decimal price, int quantity)
        {
            id_ = id;
            name_ = name;
            category_ = category;
            price_ = price;
            quantity_ = quantity;
        }
        [DisplayName("Id")]
        public int Id
        {
            get { return id_; }
            set
            {
                id_ = value;
                OnPropertyChanged("id");
            }
        }

        [DisplayName("Название")]
        public string Name
        {
            get { return name_; }
            set
            {
                name_ = value;
                OnPropertyChanged("name");
            }
        }

        [DisplayName("Категория")]
        public string Category
        {
            get { return category_; }
            set
            {
                category_ = value;
                OnPropertyChanged("category");
            }
        }

        [DisplayName("Цена")]
        public decimal Price
        {
            get { return price_; }
            set
            {
                price_ = value;
                OnPropertyChanged("price");
            }
        }

        [DisplayName("Количество")]
        public int Quantity
        {
            get { return quantity_; }
            set
            {
                quantity_ = value;
                OnPropertyChanged("quantity");
            }
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
