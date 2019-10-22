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

        [Fact]//make sure product constructor works.
        public void Test1()
        {
            //arrange
            Product product0 = new Product("bamboo",10);

            //act
            var test = product0.ProductName;

            //assert
            Assert.Equal(expected: test, actual: "bamboo");
        }


        [Fact]//make sure product constructor works.
        public void Test2()
        {
            //arrange
            Product product0 = new Product("apples", 10);

            //act
            var test = product0.ProductPrice;

            //assert
            Assert.Equal(expected: test, actual: 10);
        }
/*
        [Fact]//make sure add product works
        public void Test9()
        {
            Product product0 = new Product("bana-na-na", 10);

            //act
            DBRepository.AddProduct(product0);



            //assert
            Assert.Equal(expected: testProducts.Count, actual: 3);
        }*/


        [Fact]//make sure Location constructor works.
        public void Test3()
        {
            //arrange
            Location loc= new Location("London");

            //act
            var test = loc.LocationName;

            //assert
            Assert.Equal(expected: test, actual: "London");
        }

        [Fact]//make sure Order constructor works.
        public void Test4()
        {
            //arrange
            Order ord = new Order();

            //act
            //DBRepository.AddOrder(ord);

            //assert
            //Assert.Equal(expected: DbLibrary.customers.Count, actual: 3);

        }

        /*            testCustomers = DbLibrary.ReadAllCustomers();
                    Console.WriteLine(testCustomers.Count);
                    foreach (Customer x in testCustomers)
                    {
                        Console.WriteLine($"{x.CustID}, {x.CustomerFirstName}, {x.CustomerLastName}, {x.CustomerStreet}, {x.CustomerCity}, {x.CustomerZipCode}");
                        Console.WriteLine();
                    }*/



        [Fact]
        public void Test5()
        {
            //arrange
            Location Location1 = new Location("Fort Worth", "432 MIllbrook Ln.", "For Worth", 44444);

            //act
            var test = Location1.LocationCity;

            //assert
            Assert.Equal(expected: test, actual: "Fort Worth");
        }




        [Fact]
        public void Test6()
        {
            //arrange
            Location Location1 = new Location("Fort Worth", "432 MIllbrook Ln.", "For Worth", 44444);
            Location Location2 = new Location("Dallas", "1 MIllbrook Ln.", "Dallas", 55555);
            Location Location3 = new Location("Burleson", "2 MIllbrook Ln.", "Burleson", 66666);

    /*        //act
            DbLibrary.AddLocation(Location1);
            DbLibrary.AddLocation(Location2);
            DbLibrary.AddLocation(Location3);

            //assert
            testLocations = DbLibrary.ReadAllLocations();
            Assert.Equal(expected: DbLibrary.locations.Count, actual: 3);*/

        }

        [Fact]
        public void Test7()
        {
            //arrange
            //Order order1 = new Order(11, "Mary 27, 1979", 22);

            //act
            //var test = order1.OrderDate;

            //assert
            //Assert.Equal(expected: test, actual: "Mary 27, 1979");
        }




        [Fact]
        public void Test8()
        {
            //arrange
           // Order order1 = new Order(11, "May 27, 1979", 22);



            //act
           // DbLibrary.AddOrder(order1);


            //assert
            //testLocations = DbLibrary.ReadAllLocations();
            //Assert.Equal(expected: DbLibrary.locations.Count, actual: 3);

        }
    }
}