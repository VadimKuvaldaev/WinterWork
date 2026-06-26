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
        // Приватные поля для хранения данных
        private int id_;
        private string name_;
        private string category_;
        private decimal price_;
        private int quantity_;
        private string description_;
        private DateTime addedAt_;

        /// <summary>
        /// Уникальный идентификатор товара
        /// </summary>
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

        /// <summary>
        /// Наименование товара
        /// </summary>
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
        /// Цена товара в рублях
        /// </summary>
        [DisplayName("Цена")]
        public decimal Price
        {
            get { return price_; }
            set
            {
                price_ = value;
                OnPropertyChanged("Price");
                OnPropertyChanged("TotalValue"); // Обновляем общую стоимость
            }
        }

        /// <summary>
        /// Количество товара на складе
        /// </summary>
        [DisplayName("Количество")]
        public int Quantity
        {
            get { return quantity_; }
            set
            {
                quantity_ = value;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("TotalValue"); // Обновляем общую стоимость
            }
        }

        /// <summary>
        /// Описание товара
        /// </summary>
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

        /// <summary>
        /// Дата добавления товара в систему
        /// </summary>
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

        /// <summary>
        /// Общая стоимость всех единиц товара на складе (Цена × Количество)
        /// Вычисляемое свойство - только для чтения
        /// </summary>
        [DisplayName("Общая стоимость")]
        public decimal TotalValue
        {
            get { return Price * Quantity; }
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
        /// Конструктор по умолчанию
        /// </summary>
        public ProductItem()
        {
            AddedAt = DateTime.Now;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="category">Категория</param>
        /// <param name="price">Цена</param>
        /// <param name="quantity">Количество</param>
        /// <param name="description">Описание (необязательно)</param>
        public ProductItem(string name, string category, decimal price, int quantity, string description = "")
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = quantity;
            Description = description;
            AddedAt = DateTime.Now;
        }

        /// <summary>
        /// Уменьшение количества товара на складе
        /// </summary>
        /// <param name="amount">Количество для списания</param>
        /// <exception cref="InvalidOperationException">Если недостаточно товара</exception>
        public void DecreaseQuantity(int amount)
        {
            if (Quantity >= amount)
                Quantity -= amount;
            else
                throw new InvalidOperationException($"Недостаточно товара на складе. Доступно: {Quantity}");
        }

        /// <summary>
        /// Увеличение количества товара на складе
        /// </summary>
        /// <param name="amount">Количество для добавления</param>
        public void IncreaseQuantity(int amount)
        {
            if (amount > 0)
                Quantity += amount;
        }

        /// <summary>
        /// Строковое представление товара
        /// </summary>
        /// <returns>Наименование (Категория) - Цена - Количество шт.</returns>
        public override string ToString()
        {
            return $"{Name} ({Category}) - {Price:C} - {Quantity} шт.";
        }
    }
}
