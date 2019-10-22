using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Product
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }

        public Product() { }

        public Product(string name,int price)
        {
            this.ProductName = name;
            this.ProductPrice = price;
        }

        public Product(int ID, string name, int price)
        {
            ProductID = ID;
            ProductName = name;
            ProductPrice = price;
        }
    }
}
