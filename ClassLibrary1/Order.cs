using System;
using System.Collections.Generic;


namespace ClassLibrary1
{
    public class Order
    {
        public int      OrderID     { get; set; }
        public int      CustomerID  { get; set; }
        public int      LocationID  { get; set; }
        public IDictionary<string, int> itemsOrdered = new Dictionary<string, int>();//to hold the product and quantity

        public Order() { }
        public Order(int locationId, int customerId)
        {
            this.LocationID = locationId;
            this.CustomerID = customerId;
        }

        //this constructor is best for converting from the ENTITY TO CLASS
        public Order(int orderNum, int locationId, int customerId)
        {
            this.OrderID = orderNum;
            this.LocationID = locationId;
            this.CustomerID = customerId;
        }


    }
}
