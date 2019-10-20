//using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

namespace Project1_Mark.Models
{
    public class ProductsFromOrderViewModel
    {

        public int OrderId { get; set; }
        //[Required]
        public int ProductId { get; set; }
        //[Required]
        public int Quantity { get; set; }
    }
}
