using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class Sale : INotifyPropertyChanged
    {
        // Приватные поля для хранения данных
        private int id_;
        private int userId_;
        private string userName_;
        private DateTime saleDate_;
        private decimal totalAmount_;
        private BindingList<SaleItem> items_ = new BindingList<SaleItem>();

        /// <summary>
        /// Уникальный идентификатор продажи
        /// </summary>
        [DisplayName("ID продажи")]
        public int Id
        {
            get { return id_; }
            set
            {
                id_ = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// ID пользователя, который оформил продажу
        /// </summary>
        [DisplayName("ID пользователя")]
        public int UserId
        {
            get { return userId_; }
            set
            {
                userId_ = value;
                OnPropertyChanged("UserId");
            }
        }

        /// <summary>
        /// Имя продавца, оформившего продажу
        /// </summary>
        [DisplayName("Продавец")]
        public string UserName
        {
            get { return userName_; }
            set
            {
                userName_ = value;
                OnPropertyChanged("UserName");
            }
        }

        /// <summary>
        /// Дата и время оформления продажи
        /// </summary>
        [DisplayName("Дата продажи")]
        public DateTime SaleDate
        {
            get { return saleDate_; }
            set
            {
                saleDate_ = value;
                OnPropertyChanged("SaleDate");
            }
        }

        /// <summary>
        /// Общая сумма продажи
        /// </summary>
        [DisplayName("Итоговая сумма")]
        public decimal TotalAmount
        {
            get { return totalAmount_; }
            set
            {
                totalAmount_ = value;
                OnPropertyChanged("TotalAmount");
            }
        }

        /// <summary>
        /// Список товаров в продаже (позиции чека)
        /// </summary>
        [DisplayName("Товары")]
        public BindingList<SaleItem> Items
        {
            get { return items_; }
            set
            {
                items_ = value;
                OnPropertyChanged("Items");
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
        /// Конструктор продажи
        /// </summary>
        public Sale()
        {
            Items = new BindingList<SaleItem>();
            SaleDate = DateTime.Now; // Автоматически устанавливаем текущую дату
        }
    }
}

    