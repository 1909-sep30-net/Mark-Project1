using System;
using System.Collections.Generic;
using System.Text;
using DbLibrary.Entities;

namespace DbLibrary
{
    public class LocationsViewModel
    {
        //public Locations()
        //{
        //    Orders = new HashSet<Orders>();
        //}
        //public int CustomerId { get; set; }
        public string LocationName { get; set; }
        //public string LocationName { get; set; }
        public IEnumerable<string> locationsAll { set; get; }

        public LocationsViewModel(){}
        
        //public LocationsViewModel(int ID, string n) 
        //{
        //    this.LocationId = ID;
        //    this.LocationName = n;
        //}



        //public virtual ICollection<Orders> Orders { get; set; }
    }
}
