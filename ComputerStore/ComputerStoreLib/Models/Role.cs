using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerStoreLib.Models
{
    public enum Role
    {
        /// <summary>
        /// Администратор - полный доступ ко всем функциям
        /// Может: управлять товарами, пользователями, просматривать отчеты
        /// </summary>
        Admin,

        /// <summary>
        /// Продавец-консультант - ограниченный доступ
        /// Может: просматривать товары, оформлять продажи, работать с корзиной
        /// Не может: управлять товарами (добавлять/редактировать/удалять)
        /// </summary>
        Seller
    }
}
