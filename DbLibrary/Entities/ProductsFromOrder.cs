using System;
using System.Collections.Generic;

namespace DbLibrary.Entities
{
    public partial class ProductsFromOrder
    {
        public int ProductsFromOrder1 { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateModified { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
