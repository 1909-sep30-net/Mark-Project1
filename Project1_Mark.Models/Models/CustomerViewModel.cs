using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_Mark.Models
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
