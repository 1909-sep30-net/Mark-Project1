using System;
using System.Collections.Generic;

namespace DbLibrary.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
