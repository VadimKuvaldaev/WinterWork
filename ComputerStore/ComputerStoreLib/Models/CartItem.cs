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
        // Товар в корзине
        private ProductItem product_;
        // Количество товара
        private int quantity_;

        /// <summary>
        /// Товар в корзине
        /// </summary>
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

        /// <summary>
        /// Количество единиц товара
        /// </summary>
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

        /// <summary>
        /// Итоговая стоимость позиции (цена * количество)
        /// Вычисляемое свойство - только для чтения
        /// </summary>
        [DisplayName("Итого")]
        public decimal TotalPrice
        {
            get { return Product != null ? Product.Price * Quantity : 0; }
        }

        /// <summary>
        /// Наименование товара (для отображения в таблице)
        /// Вычисляемое свойство - только для чтения
        /// </summary>
        [DisplayName("Наименование")]
        public string ProductName
        {
            get { return Product?.Name ?? ""; }
        }

        /// <summary>
        /// Категория товара (для отображения в таблице)
        /// Вычисляемое свойство - только для чтения
        /// </summary>
        [DisplayName("Категория")]
        public string Category
        {
            get { return Product?.Category ?? ""; }
        }

        /// <summary>
        /// Цена товара (для отображения в таблице)
        /// Вычисляемое свойство - только для чтения
        /// </summary>
        [DisplayName("Цена")]
        public decimal Price
        {
            get { return Product?.Price ?? 0; }
        }

        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызов события изменения свойства
        /// </summary>
        /// <param name="prop">Имя измененного свойства</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Конструктор позиции корзины
        /// </summary>
        /// <param name="product">Товар</param>
        /// <param name="quantity">Количество</param>
        public CartItem(ProductItem product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
