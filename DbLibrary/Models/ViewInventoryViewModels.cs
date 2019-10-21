using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary
{
    public class ViewInventoryViewModels
    {
        public int productId {get; set;}//return the 
        public IEnumerable<InventoryViewModel> InventoriesAll { set; get; }//to give the inventory
        //public IDictionary<int, int> ProdsAndQuants { get; set; }//to be filled by the modelbinding


        public ViewInventoryViewModels() { }
    }
}
