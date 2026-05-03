using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ComputerPartsShopLibrary.Model
{
    public class CartItem
    {
        public ProductItem Product { get; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity; 

        public CartItem(ProductItem product, int quantity)
        {
            Product = product; 
            Quantity = quantity; 
        }
        
    }
}

