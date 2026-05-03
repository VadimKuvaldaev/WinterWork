using ComputerPartsShopLibrary.Date;
using ComputerPartsShopLibrary.Model;
using LiveCharts.Wpf.Charts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerPartsShopLibrary.Presenter
{
    public class CartPresenter
    {
        private Cart _cart;
        private WarehouseManager _warehouse;
        private Database _db;

        public CartPresenter(Cart cart, WarehouseManager wm, Database db)
        {
            _cart = cart; _warehouse = wm; _db = db;
        }

        public void AddToCart(int productId, int qty)
        {
            var product = _warehouse.GetProductById(productId);
            if (product != null && product.Quantity >= qty) _cart.AddItem(product, qty);
        }

        public void RemoveFromCart(int productId) => _cart.RemoveItem(productId);
        public void Checkout()
        {
            foreach (var item in _cart.GetItems())
            {
                item.Product.DecreaseQuantity(item.Quantity);
                _db.ExecuteQuery($"INSERT INTO sales (prod_id, qty) VALUES ({item.Product.Id}, {item.Quantity})");
            }
            _cart.Clear();
        }
    }
}
