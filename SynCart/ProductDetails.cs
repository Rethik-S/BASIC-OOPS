using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynCart
{
    public class ProductDetails
    {

        //field
        private static int s_productId = 100;

        //Auto property
        public string ProductId { get; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int ShippingDuration { get; set; }

        //constructor
        public ProductDetails(string productName, double price, int stock, int shippingDuration)
        {
            s_productId++;
            ProductId = "PID" + s_productId;

            ProductName = productName;
            Price = price;
            Stock = stock;
            ShippingDuration = shippingDuration;
        }
    }
}