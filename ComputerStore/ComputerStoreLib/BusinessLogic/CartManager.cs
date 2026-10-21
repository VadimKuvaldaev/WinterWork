using ComputerStoreLib.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ComputerStoreLib
{
    public class CartManager
    {
        private Cart cart = new Cart();
        private ProductRepository productRepo;
        private SaleRepository saleRepo;

        public CartManager(ProductRepository productRepo, SaleRepository saleRepo)
        {
            this.productRepo = productRepo;
            this.saleRepo = saleRepo;
        }

        public Cart GetCart() => cart;

        public bool AddToCart(ProductItem product, int quantity)
        {
            if (product == null || quantity <= 0) return false;
            if (product.Quantity < quantity) return false;

            // Списываем со склада
            product.Quantity -= quantity;
            productRepo.UpdateQuantity(product.Id, product.Quantity);

            cart.AddItem(product, quantity);
            return true;
        }

        public bool RemoveFromCart(CartItem item)
        {
            if (item == null) return false;

            // Возвращаем на склад
            var product = productRepo.GetAllProducts().FirstOrDefault(p => p.Id == item.Product.Id);
            if (product != null)
            {
                product.Quantity += item.Quantity;
                productRepo.UpdateQuantity(product.Id, product.Quantity);
            }

            cart.RemoveItem(item.Product.Id);
            return true;
        }

        public void ClearCart()
        {
            foreach (var item in cart.Items)
            {
                var product = productRepo.GetAllProducts().FirstOrDefault(p => p.Id == item.Product.Id);
                if (product != null)
                {
                    product.Quantity += item.Quantity;
                    productRepo.UpdateQuantity(product.Id, product.Quantity);
                }
            }
            cart.Clear();
        }

        public bool Checkout(User currentUser)
        {
            if (cart.IsEmpty) return false;

            var sale = new Sale(currentUser.Id);
            foreach (var item in cart.Items)
            {
                sale.Items.Add(new SaleItem(item.Product.Id, item.Product.Name, item.Product.Category, item.Product.Price, item.Quantity));
            }
            sale.TotalAmount = cart.TotalSum;

            if (saleRepo.AddSale(sale))
            {
                cart.Clear();
                return true;
            }
            return false;
        }
    }
}