using System;
using System.Collections.Generic;
using System.Text;

namespace DbLibrary
{
    public class CustomerViewModel
    {
        public int CustID { get; set; }
        //[Required]
        public string CustomerFirstName { get; set; }
        //[Required]
        public string CustomerLastName { get; set; }


        public CustomerViewModel() { }

        public CustomerViewModel(int ID, string f, string l)
        {
            this.CustID = ID;
            this.CustomerFirstName = f;
            this.CustomerLastName = l;
        }
    }
}