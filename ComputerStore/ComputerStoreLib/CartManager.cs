using ComputerStoreLib.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ComputerStoreLib
{
    public class CartManager
    {
        private readonly PgComputerStoreLoader loader_;
        private readonly Cart cart_;
        private readonly DataGridView cartGrid_;
        private readonly Label cartTotalLabel_;
        private readonly Label cartCountLabel_;
        private readonly Button checkoutButton_;

        public CartManager(
            PgComputerStoreLoader loader,
            Cart cart,
            DataGridView cartGrid,
            Label cartTotalLabel,
            Label cartCountLabel,
            Button checkoutButton)
        {
            loader_ = loader;
            cart_ = cart;
            cartGrid_ = cartGrid;
            cartTotalLabel_ = cartTotalLabel;
            cartCountLabel_ = cartCountLabel;
            checkoutButton_ = checkoutButton;
        }

        /// <summary>
        /// Обновление отображения корзины
        /// </summary>
        public void UpdateDisplay()
        {
            if (cartGrid_ == null || cartTotalLabel_ == null || cartCountLabel_ == null || checkoutButton_ == null)
            {
                return;
            }

            cartGrid_.DataSource = null;
            cartGrid_.DataSource = cart_.Items;
            cartTotalLabel_.Text = $"Итого: {cart_.TotalSum:C}";
            cartCountLabel_.Text = $"Позиций: {cart_.Count}";
            checkoutButton_.Enabled = !cart_.IsEmpty;
            cartGrid_.Refresh();
        }

        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        public bool AddToCart(ProductItem product, int quantity)
        {
            try
            {
                if (product == null)
                {
                    MessageBox.Show("Товар не выбран", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Проверяем остаток
                if (product.Quantity < quantity)
                {
                    MessageBox.Show($"На складе только {product.Quantity} шт.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Проверяем, есть ли уже такой товар в корзине
                var existingItem = cart_.Items.FirstOrDefault(i => i.Product.Id == product.Id);
                if (existingItem != null)
                {
                    int totalQuantity = existingItem.Quantity + quantity;
                    if (totalQuantity > product.Quantity)
                    {
                        MessageBox.Show($"Нельзя добавить больше, чем есть на складе. Доступно: {product.Quantity} шт.",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // Списываем товар со склада
                if (!ReserveProductFromStock(product.Id, quantity))
                    return false;

                // Добавляем в корзину
                cart_.AddItem(product, quantity);
                UpdateDisplay();

                MessageBox.Show(
                    $"Товар '{product.Name}' добавлен в корзину\n" +
                    $"Количество: {quantity} шт.\n" +
                    $"Остаток на складе: {product.Quantity - quantity} шт.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Удаление товара из корзины
        /// </summary>
        public bool RemoveFromCart(CartItem item)
        {
            try
            {
                if (item == null)
                {
                    MessageBox.Show("Товар не выбран", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (item.Quantity > 1)
                {
                    return ShowRemoveDialog(item);
                }
                else
                {
                    return RemoveSingleItem(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Очистка корзины
        /// </summary>
        public void ClearCart()
        {
            try
            {
                // Возвращаем все товары на склад
                foreach (var item in cart_.Items.ToList())
                {
                    ReturnProductToStock(item.Product.Id, item.Quantity);
                }

                cart_.Clear();
                UpdateDisplay();

                MessageBox.Show("Корзина очищена. Все товары возвращены на склад.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка очистки корзины: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Диалог удаления нескольких единиц товара
        /// </summary>
        private bool ShowRemoveDialog(CartItem item)
        {
            var form = new Form
            {
                Text = "Удаление из корзины",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                Size = new System.Drawing.Size(450, 160)
            };

            var label = new Label
            {
                Text = $"В корзине {item.Quantity} шт. товара '{item.ProductName}'.\nВыберите действие:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(400, 50),
                Font = new System.Drawing.Font("Segoe UI", 10)
            };
            form.Controls.Add(label);

            var btnDeleteOne = new Button
            {
                Text = "Удалить 1 шт.",
                Location = new System.Drawing.Point(20, 80),
                Size = new System.Drawing.Size(120, 30),
                DialogResult = DialogResult.Yes
            };
            form.Controls.Add(btnDeleteOne);

            var btnDeleteAll = new Button
            {
                Text = "Удалить все",
                Location = new System.Drawing.Point(155, 80),
                Size = new System.Drawing.Size(120, 30),
                DialogResult = DialogResult.No
            };
            form.Controls.Add(btnDeleteAll);

            var btnCancel = new Button
            {
                Text = "Отмена",
                Location = new System.Drawing.Point(290, 80),
                Size = new System.Drawing.Size(120, 30),
                DialogResult = DialogResult.Cancel
            };
            form.Controls.Add(btnCancel);

            var result = form.ShowDialog();

            if (result == DialogResult.Yes)
            {
                // Удаляем 1 единицу и возвращаем на склад
                ReturnProductToStock(item.Product.Id, 1);

                var cartItem = cart_.Items.First(i => i.Product.Id == item.Product.Id);
                cartItem.Quantity -= 1;

                if (cartItem.Quantity <= 0)
                {
                    cart_.RemoveItem(item.Product.Id);
                }

                UpdateDisplay();
                MessageBox.Show($"Удалена 1 единица товара '{item.ProductName}'\nТовар возвращен на склад",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else if (result == DialogResult.No)
            {
                // Удаляем весь товар и возвращаем на склад
                ReturnProductToStock(item.Product.Id, item.Quantity);
                cart_.RemoveItem(item.Product.Id);

                UpdateDisplay();
                MessageBox.Show($"Товар '{item.ProductName}' полностью удален из корзины\n{item.Quantity} шт. возвращено на склад",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаление одной единицы товара
        /// </summary>
        private bool RemoveSingleItem(CartItem item)
        {
            var result = MessageBox.Show(
                $"Удалить товар '{item.ProductName}' из корзины?\n(1 шт. будет возвращено на склад)",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Возвращаем товар на склад
                ReturnProductToStock(item.Product.Id, 1);
                cart_.RemoveItem(item.Product.Id);

                UpdateDisplay();
                MessageBox.Show($"Товар '{item.ProductName}' удален из корзины\n1 шт. возвращено на склад",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Оформление продажи
        /// </summary>
        public bool Checkout(User currentUser)
        {
            if (cart_.IsEmpty)
            {
                MessageBox.Show("Корзина пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                var sale = new Sale
                {
                    UserId = currentUser.Id,
                    UserName = currentUser.FullName ?? currentUser.Login,
                    SaleDate = DateTime.Now,
                    Items = new BindingList<SaleItem>()
                };

                foreach (var cartItem in cart_.Items.ToList())
                {
                    // Товар уже списан со склада при добавлении в корзину
                    sale.Items.Add(new SaleItem
                    {
                        ProductId = cartItem.Product.Id,
                        ProductName = cartItem.ProductName,
                        Category = cartItem.Product.Category,
                        Price = cartItem.Price,
                        Quantity = cartItem.Quantity,
                        TotalPrice = cartItem.TotalPrice
                    });

                    sale.TotalAmount += cartItem.TotalPrice;
                }

                if (loader_.AddSale(sale))
                {
                    cart_.Clear();
                    UpdateDisplay();
                    MessageBox.Show($"Продажа оформлена!\nСумма: {sale.TotalAmount:C}",
                        "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    // Если продажа не сохранилась, возвращаем товары на склад
                    foreach (var cartItem in cart_.Items.ToList())
                    {
                        ReturnProductToStock(cartItem.Product.Id, cartItem.Quantity);
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка оформления продажи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // При ошибке возвращаем товары на склад
                foreach (var cartItem in cart_.Items.ToList())
                {
                    ReturnProductToStock(cartItem.Product.Id, cartItem.Quantity);
                }

                return false;
            }
        }

        /// <summary>
        /// Списание товара со склада
        /// </summary>
        private bool ReserveProductFromStock(int productId, int quantity)
        {
            try
            {
                var product = loader_.LoadProducts().FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    MessageBox.Show($"Товар с ID {productId} не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (product.Quantity < quantity)
                {
                    MessageBox.Show($"Недостаточно товара '{product.Name}'. Доступно: {product.Quantity} шт.",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                product.Quantity -= quantity;
                loader_.UpdateProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка списания товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Возврат товара на склад
        /// </summary>
        private void ReturnProductToStock(int productId, int quantity)
        {
            try
            {
                var product = loader_.LoadProducts().FirstOrDefault(p => p.Id == productId);
                if (product == null)
                {
                    MessageBox.Show($"Товар с ID {productId} не найден", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                product.Quantity += quantity;
                loader_.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка возврата товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}