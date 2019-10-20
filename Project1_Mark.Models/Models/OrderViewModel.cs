//using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace Project1_Mark.Models
{
    public class OrderViewModel
    {
        //public Orders()
        //{
        //    ProductsFromOrder = new HashSet<ProductsFromOrder>();
        //}

        public int OrderId { get; set; }
        //[Required] 
        public int LocationId { get; set; }
        //[Required] 
        public int CustomerId { get; set; }
        //public DateTime DateModified { get; set; }

        //public virtual Customers Customer { get; set; }
        //public virtual Locations Location { get; set; }
        public virtual ICollection<ProductsFromOrderViewModel> ProductsFromOrder { get; set; }

    }
}
