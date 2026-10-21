namespace ComputerStoreLib.Models
{
    public class CartItem
    {
        public ProductItem Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product != null ? Product.Price * Quantity : 0;
        public string ProductName => Product?.Name ?? "";
        public string Category => Product?.Category ?? "";
        public decimal Price => Product?.Price ?? 0;
        public CartItem(ProductItem product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}