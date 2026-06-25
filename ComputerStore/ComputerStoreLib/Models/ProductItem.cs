using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class ProductItem : INotifyPropertyChanged
    {
        private int id_;
        private string name_;
        private string category_;
        private decimal price_;
        private int quantity_;
        private string description_;
        private DateTime addedAt_;

        [DisplayName("ID")]
        public int Id
        {
            get { return id_; }
            set
            {
                id_ = value;
                OnPropertyChanged("Id");
            }
        }

        [DisplayName("Наименование")]
        public string Name
        {
            get { return name_; }
            set
            {
                name_ = value;
                OnPropertyChanged("Name");
            }
        }

        [DisplayName("Категория")]
        public string Category
        {
            get { return category_; }
            set
            {
                category_ = value;
                OnPropertyChanged("Category");
            }
        }

        [DisplayName("Цена")]
        public decimal Price
        {
            get { return price_; }
            set
            {
                price_ = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("TotalValue");
            }
        }

        [DisplayName("Количество")]
        public int Quantity
        {
            get { return quantity_; }
            set
            {
                quantity_ = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("TotalValue");
            }
        }

        [DisplayName("Описание")]
        public string Description
        {
            get { return description_; }
            set
            {
                description_ = value;
                OnPropertyChanged("Description");
            }
        }

        [DisplayName("Дата добавления")]
        public DateTime AddedAt
        {
            get { return addedAt_; }
            set
            {
                addedAt_ = value;
                OnPropertyChanged("AddedAt");
            }
        }

        [DisplayName("Общая стоимость")]
        public decimal TotalValue
        {
            get { return Price * Quantity; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public ProductItem()
        {
            AddedAt = DateTime.Now;
        }

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
            if (Quantity >= amount)
                Quantity -= amount;
            else
                throw new InvalidOperationException($"Недостаточно товара на складе. Доступно: {Quantity}");
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount > 0)
                Quantity += amount;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - {Price:C} - {Quantity} шт.";
        }
    }
}
