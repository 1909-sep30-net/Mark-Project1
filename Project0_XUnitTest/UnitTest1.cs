using System;
using System.Collections.Generic;
using ClassLibrary1;
using DbLibrary.Entities;
using DBLibrary;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Microsoft.Extensions.Logging;
using NLog;
using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;


namespace Project0_XUnitTest
{
    public class UnitTest1
    {
        //create logging variables.
        private readonly ILogger<UnitTest1> _logger;
        private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new repository given a data source and instantiates logging
        /// </summary>
        /// <param name="logger">The logger</param>
        public UnitTest1(ILogger<UnitTest1> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*************************************************************************/

        private Customer customer;
        private Customers customers;
        private Location location;
        private Locations locations;
        private Product product;
        private Products products;
        private Order order;
        private Orders orders;

        [Fact]//make sure product constructor works.
        public void Test1()
        {
            //arrange
            Product product0 = new Product("bamboo",10);

            //act
            var test = product0.ProductName;

            //assert
            Assert.Equal(expected: "bamboo" , actual: test);
        }

        //make sure 
        public void Test2()
        {
            //arrange
            int fivefive = 55;

            //act
            customer.CustID = fivefive;

            //assert
            Assert.Equal(expected: 55, actual: customer.CustID);


        }
        //make sure defualt values are set
        public void Test3()
        {
            //arrange
            Customer testCust = new Customer(101, "fName", "lName");

            //act


            //assert
            Assert.Equal(expected: 00000, actual: testCust.CustomerZipCode);

        }

        [Fact]//make sure product constructor works.
        public void Test4()
        {
            //arrange
            Product product0 = new Product("apples", 10);

            //act
            var test = product0.ProductPrice;

            //assert
            Assert.Equal(expected: 10, actual: test);
        }

        [Fact]//make sure  product constructor works
        public void Test5()
        {
            //arrange
            Product product0 = new Product("bana-na-na", 10);

            //act

            //assert
            Assert.Equal(expected: "bana-na-na", actual: product0.ProductName);
        }


        [Fact]//make sure Location constructor works.
        public void Test6()
        {
            //arrange
            Location loc= new Location("London");

            //act
            var test = loc.LocationName;

            //assert
            Assert.Equal(expected: "London", actual: test);
        }

        [Fact]//make sure Order constructor works.
        public void Test7()
        {
            //arrange
            Order ord = new Order();

            //act
            ord.LocationID = 321;

            //assert
            Assert.Equal(expected: 321, actual: ord.LocationID);

        }


        [Fact]//test Location constructor with all params provided
        public void Test8()
        {
            //arrange
            Location Location1 = new Location("Fort Worth", "432 MIllbrook Ln.", "For Worth", 44444);

            //act
            var test = Location1.LocationCity;

            //assert
            Assert.Equal(expected: "Fort Worth", actual: test);
        }




        [Fact]
        public void Test9()
        {
            //arrange
            Order order = new Order();

            //act
            order.itemsOrdered.Add("jam", 7);
            order.itemsOrdered.Add("jem", 8);
            order.itemsOrdered.Add("jim", 9);


            //assert
            Assert.Equal(expected: 3, actual: order.itemsOrdered.Count);

        }

        [Fact]
        public void Test10()
        {
            //arrange
            Order order = new Order();

            //act
            order.itemsOrdered.Add("jam", 7);
            order.itemsOrdered.Add("jem", 8);
            order.itemsOrdered.Add("jim", 9);

            //assert
            Assert.Equal(expected: 7, actual: order.itemsOrdered["jam"]);
        }


        [Fact]//verify overwritting of values in Order dictionary
        public void Test11()
        {
            //arrange
            Order order = new Order();

            //act
            order.itemsOrdered.Add("jam", 7);
            order.itemsOrdered.Add("jem", 8);
            order.itemsOrdered.Add("jim", 9);
            order.itemsOrdered.Add("jim", 1);

            //assert
            Assert.Equal(expected: 1, actual: order.itemsOrdered["jim"]);
        }

        [Fact]
        public void Test12()
        {
            //arrange
            customer.CustID = 1;
            customer.CustomerFirstName = "Milly";
            customer.CustomerLastName = "Vanilly";

            //act
            customers = Mapper.MapCustomer(customer);

            //assert
            Assert.Equal(expected: "Milly", actual: customers.CustomerFirstName);
        }
    }
}