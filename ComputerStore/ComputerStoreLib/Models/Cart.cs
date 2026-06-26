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
        // Список товаров в корзине
        private BindingList<CartItem> items_ = new BindingList<CartItem>();
        // Общая сумма корзины
        private decimal totalSum_;

        /// <summary>
        /// Товары в корзине
        /// </summary>
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

        /// <summary>
        /// Итоговая сумма всех товаров в корзине
        /// </summary>
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

        /// <summary>
        /// Количество позиций (разных товаров) в корзине
        /// </summary>
        [DisplayName("Количество позиций")]
        public int Count
        {
            get { return Items.Count; }
        }

        /// <summary>
        /// Проверка, пуста ли корзина
        /// </summary>
        [DisplayName("Корзина пуста")]
        public bool IsEmpty
        {
            get { return Items.Count == 0; }
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
        /// Конструктор корзины
        /// </summary>
        public Cart()
        {
            // При изменении списка товаров пересчитываем итоговую сумму
            Items.ListChanged += (s, e) => UpdateTotalSum();
        }

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="product">Товар для добавления</param>
        /// <param name="quantity">Количество</param>
        /// <exception cref="ArgumentException">Если количество <= 0</exception>
        /// <exception cref="InvalidOperationException">Если недостаточно товара на складе</exception>
        public void AddItem(ProductItem product, int quantity)
        {
            // Проверка: количество должно быть положительным
            if (quantity <= 0)
                throw new ArgumentException("Количество должно быть положительным");

            // Проверка: достаточно ли товара на складе
            if (product.Quantity < quantity)
                throw new InvalidOperationException($"Недостаточно товара на складе. Доступно: {product.Quantity}");

            // Проверяем, есть ли уже такой товар в корзине
            var existingItem = Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (existingItem != null)
            {
                // Если товар уже есть - увеличиваем количество
                if (product.Quantity < existingItem.Quantity + quantity)
                    throw new InvalidOperationException($"Недостаточно товара на складе. Доступно: {product.Quantity}");

                existingItem.Quantity += quantity;
            }
            else
            {
                // Если товара нет - добавляем новый
                Items.Add(new CartItem(product, quantity));
            }

            // Пересчитываем итоговую сумму
            UpdateTotalSum();
        }

        /// <summary>
        /// Удаление товара из корзины по ID
        /// </summary>
        /// <param name="productId">ID товара для удаления</param>
        public void RemoveItem(int productId)
        {
            // Ищем товар в корзине
            var item = Items.FirstOrDefault(i => i.Product.Id == productId);

            if (item != null)
            {
                // Удаляем товар из списка
                Items.Remove(item);
                // Пересчитываем итоговую сумму
                UpdateTotalSum();
            }
        }

        /// <summary>
        /// Полная очистка корзины
        /// </summary>
        public void Clear()
        {
            Items.Clear();
            UpdateTotalSum();
        }

        /// <summary>
        /// Пересчет итоговой суммы корзины
        /// </summary>
        private void UpdateTotalSum()
        {
            // Суммируем общую стоимость всех товаров в корзине
            TotalSum = Items.Sum(item => item.TotalPrice);
            // Уведомляем об изменении количества и состояния корзины
            OnPropertyChanged("Count");
            OnPropertyChanged("IsEmpty");
        }
    }
}
