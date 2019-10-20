using System;
using System.Collections.Generic;
using System.Text;
//using DBLibrary;

namespace ClassLibrary1
{
    public class Customer
    {
       // private static int CustomerID = 0;

        // backing field for the "CustomerFirstName" and "CustomerLastName" properties.
        // necessary to define this to be able to add validation to the setter.
        private string _name;
        private string _lname;

        public int      CustID              { get; set; }
        public string   CustomerFirstName
        {
            // expression-body syntax for accessing the backing field.
            // equivalent to "get { return _name; }"
            get => _name;
            set
            {
                // "value" is the value passed to the setter.
                if (value.Length == 0 || value.Length > 20)
                {
                    // good practice to provide useful messages when throwing exceptions,
                    // as well as the name of the relevant parameter if applicable.
                    throw new ArgumentException("First Name must not be empty or greater than 20 characters.", nameof(value));
                }
            _name = value;
            }
        }
        public string CustomerLastName
        {
            // expression-body syntax for accessing the backing field.
            // equivalent to "get { return _name; }"
            get => _lname;
            set
            {
                // "value" is the value passed to the setter.
                if (value.Length == 0 || value.Length > 20)
                {
                    // good practice to provide useful messages when throwing exceptions,
                    // as well as the name of the relevant parameter if applicable.
                    throw new ArgumentException("Last Name must not be empty or greater than 20 characters.", nameof(value));
                }
                _lname = value;
            }
        }
        public string   CustomerStreet      { get; set; }
        public string   CustomerCity        { get; set; }
        public int      CustomerZipCode     { get; set; }

        //create a default customer
        public Customer() 
        {

            this.CustomerStreet = null;
            this.CustomerCity = null;
            this.CustomerZipCode = 0;
        }

        //create a customer with arguments
        public Customer(string fName, string lName, string street = null, string city = null, int zip = 00000)
        {

            this.CustomerFirstName  = fName;
            this.CustomerLastName   = lName;
            this.CustomerStreet     = street;
            this.CustomerCity       = city;
            this.CustomerZipCode    = zip;
        }

        public Customer(int ID, string fName, string lName, string street = null, string city = null, int zip = 00000)
        {
            this.CustID = ID;
            this.CustomerFirstName = fName;
            this.CustomerLastName = lName;
            this.CustomerStreet = street;
            this.CustomerCity = city;
            this.CustomerZipCode = zip;
        }
    }
}
