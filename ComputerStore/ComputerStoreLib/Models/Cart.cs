using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public class Cart : INotifyPropertyChanged
    {
        private BindingList<CartItem> items_ = new BindingList<CartItem>();
        private decimal totalSum_;

        [DisplayName("Товары в корзине")]
        public BindingList<CartItem> Items
        {
            get { return items_; }
            set
            {
                items_ = value;
                OnPropertyChanged("Items");
                OnPropertyChanged("Count");
                OnPropertyChanged("IsEmpty");
            }
        }

        [DisplayName("Итоговая сумма")]
        public decimal TotalSum
        {
            get { return totalSum_; }
            private set
            {
                totalSum_ = value;
                OnPropertyChanged("TotalSum");
            }
        }

        [DisplayName("Количество позиций")]
        public int Count
        {
            get { return Items.Count; }
        }

        [DisplayName("Корзина пуста")]
        public bool IsEmpty
        {
            get { return Items.Count == 0; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public Cart()
        {
            Items.ListChanged += (s, e) => UpdateTotalSum();
        }

        public void AddItem(ProductItem product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Количество должно быть положительным");

            if (product.Quantity < quantity)
                throw new InvalidOperationException($"Недостаточно товара на складе. Доступно: {product.Quantity}");

            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (product.Quantity < existingItem.Quantity + quantity)
                    throw new InvalidOperationException($"Недостаточно товара на складе. Доступно: {product.Quantity}");

                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem(product, quantity));
            }

            UpdateTotalSum();
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                Items.Remove(item);
                UpdateTotalSum();
            }
        }

        public void Clear()
        {
            Items.Clear();
            UpdateTotalSum();
        }

        private void UpdateTotalSum()
        {
            TotalSum = Items.Sum(item => item.TotalPrice);
            OnPropertyChanged("Count");
            OnPropertyChanged("IsEmpty");
        }
    }
}
