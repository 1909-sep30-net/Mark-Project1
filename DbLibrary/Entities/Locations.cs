using System;
using System.Collections.Generic;

namespace DbLibrary.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Orders = new HashSet<Orders>();
        }

        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTime DateModified { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
