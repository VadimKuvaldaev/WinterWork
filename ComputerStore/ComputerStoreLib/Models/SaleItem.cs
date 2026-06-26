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
        // Приватные поля для хранения данных
        private int productId_;
        private string productName_;
        private string category_;
        private decimal price_;
        private int quantity_;
        private decimal totalPrice_;

        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
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

        /// <summary>
        /// Наименование товара
        /// </summary>
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

        /// <summary>
        /// Категория товара (Процессоры, Видеокарты и т.д.)
        /// </summary>
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

        /// <summary>
        /// Цена товара на момент продажи
        /// </summary>
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

        /// <summary>
        /// Количество товара
        /// </summary>
        [DisplayName("Количество")]
        public int Quantity
        {
            get { return quantity_; }
            set
            {
                quantity_ = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("TotalPrice"); // Пересчитываем итоговую сумму
            }
        }

        /// <summary>
        /// Итоговая сумма по позиции (Цена × Количество)
        /// </summary>
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
        /// Строковое представление позиции продажи
        /// </summary>
        /// <returns>Наименование - Количество шт. х Цена = Итого</returns>
        public override string ToString()
        {
            return $"{ProductName} - {Quantity} шт. x {Price:C} = {TotalPrice:C}";
        }
    }
}
