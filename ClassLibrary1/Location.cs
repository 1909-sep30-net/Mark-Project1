using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Location
    {


        public int      locID           { get; set; }
        public string   LocationName    { get; set; }
        public string   LocationStreet  { get; set; }
        public string   LocationCity    { get; set; }
        public int      LocationZip     { get; set; }


        public Location()  { }

        public Location(string loc, string street = null, string city = null, int zip = 00000)
        {
            LocationName = loc;
            LocationStreet = street;
            LocationCity = city;
            LocationZip = zip;
        }

        public Location(int ID, string loc, string street = null, string city = null, int zip = 00000)
        {
            locID = ID;
            LocationName = loc;
            LocationStreet = street;
            LocationCity = city;
            LocationZip = zip;
        }
    }
}
