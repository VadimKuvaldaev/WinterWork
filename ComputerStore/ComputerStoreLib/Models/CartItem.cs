using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class CartItem : INotifyPropertyChanged
    {
        private ProductItem product_;
        private int quantity_;

        [DisplayName("Товар")]
        public ProductItem Product
        {
            get { return product_; }
            set
            {
                product_ = value;
                OnPropertyChanged("Product");
                OnPropertyChanged("ProductName");
                OnPropertyChanged("Category");
                OnPropertyChanged("Price");
                OnPropertyChanged("TotalPrice");
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
            get { return Product != null ? Product.Price * Quantity : 0; }
        }

        [DisplayName("Наименование")]
        public string ProductName
        {
            get { return Product?.Name ?? ""; }
        }

        [DisplayName("Категория")]
        public string Category
        {
            get { return Product?.Category ?? ""; }
        }

        [DisplayName("Цена")]
        public decimal Price
        {
            get { return Product?.Price ?? 0; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public CartItem(ProductItem product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
