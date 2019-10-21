using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary
{
    public class InventoryViewModel
    {
        //public int InventoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string LocationName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        //public List<int> QuantItems { get; set; }
        
        //constructor
        public InventoryViewModel()
        {

        }

        //constructor
        public InventoryViewModel(int id,string pn, string ln, decimal d, int q)
        {
            this.ProductId = id;
            this.ProductName = pn;
            this.LocationName = ln;
            this.ProductPrice = d;
            this.ProductQuantity = q;
        }
    }
}
