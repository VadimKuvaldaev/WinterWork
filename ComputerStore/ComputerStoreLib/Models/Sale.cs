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
        private int id_;
        private int userId_;
        private string userName_;
        private DateTime saleDate_;
        private decimal totalAmount_;
        private BindingList<SaleItem> items_ = new BindingList<SaleItem>();

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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Sale()
        {
            Items = new BindingList<SaleItem>();
            SaleDate = DateTime.Now;
        }
    }
}
