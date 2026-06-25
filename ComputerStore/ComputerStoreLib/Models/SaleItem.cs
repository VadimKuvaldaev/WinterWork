using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class SaleItem : INotifyPropertyChanged
    {
        private int productId_;
        private string productName_;
        private string category_;
        private decimal price_;
        private int quantity_;
        private decimal totalPrice_;

        [DisplayName("ID товара")]
        public int ProductId
        {
            get { return productId_; }
            set
            {
                productId_ = value;
                OnPropertyChanged("ProductId");
            }
        }

        [DisplayName("Наименование")]
        public string ProductName
        {
            get { return productName_; }
            set
            {
                productName_ = value;
                OnPropertyChanged("ProductName");
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
                OnPropertyChanged("TotalPrice");
            }
        }

        [DisplayName("Итого")]
        public decimal TotalPrice
        {
            get { return totalPrice_; }
            set
            {
                totalPrice_ = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
