using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using DbLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DBLibrary
{
    public class searching
    {
        //create logging variables.
        private readonly ILogger<searching> _logger;

        /// <summary>
        /// Initializes a new repository given a data source and instantiates logging
        /// </summary>
        /// <param name="logger">The logger</param>
        public searching(ILogger<searching> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*************************************************************************/



        /// <summary>
        /// this presents a menu to allow the user to search in 2 ways
        /// </summary>
        /// <param name="context"></param>
        public static void goSearching(DBRepository repo)
        {
            string userType;
            //menu to choose which search to do
            do
            {
                Console.WriteLine("\n Would you like to search for display details of an order. " +
                "display all order history of a store location, "+
                "or display all order history of a customer, ");

                Console.WriteLine("\n\n\tA - Find details of an order.\n\tB - Display the history of a location.\n\tC - Display a customers order history.");
                userType = Console.ReadLine();
                userType = userType.ToUpper();  //to accept upper and lower case letters.
            } while (!(userType.Equals("A") || userType.Equals("B") || userType.Equals("C")));

            switch (userType)
            {
                case "A":
                    OrderDetails(repo);
                    break;
                case "B":
                    LocationHistory(repo);
                    break;
                case "C":
                    CustomerHistory(repo);
                    break;
            }
        }

        /// <summary>
        /// this takes a DB context and allows user to choose an order ID and search a its details
        /// </summary>
        /// <param name="context"></param>
        public static void OrderDetails(DBRepository repo)
        {
            //get list of all orders
            var orders = repo.ReadAllOrdersInTable();

            //list all customers
            Console.WriteLine("Please choose a Order ID number from the list below to display the items in it.");
            foreach (var item in orders)
            {
                Console.WriteLine($"OrderID =>{item.OrderId} -- LocationID =>{item.LocationId} -- CustomerID =>{item.CustomerId}");
            }

            string usersChoice = Console.ReadLine();
            int usersChoice1 = Convert.ToInt32(usersChoice);

            var orderToDisplay = orders
                .Where(x => x.OrderId == usersChoice1).First();

            int orderProdsToDisplay = orderToDisplay.OrderId;

            //get all that customers orders
            Order custOrders = repo.ReadOrderByOrderId(orderProdsToDisplay);

            //display all orders
            Console.WriteLine($"Here are the items in order #{usersChoice1}\n=======================================");
            foreach (var item in custOrders.itemsOrdered)
            {
                Console.WriteLine($"\t={item.Key}= ={item.Value}=");
            }
        }

        /// <summary>
        /// This takes a DB context and allows the user to view the order history of a particular location
        /// </summary>
        /// <param name="context"></param>
        public static void LocationHistory(DBRepository repo)
        {
            Console.WriteLine("Please enter the NUMBER of the location you'd like to see the order history of.");
            var locations = repo.ReadAllLocations();
            foreach (var item in locations)
            {
                Console.WriteLine($"\t{item.LocationId}---{item.LocationName}");
            }
            string response = Console.ReadLine();
            int response1 = Convert.ToInt32(response);

            //get all orders and sort them by locationID
            var locOrders = repo.ReadAllOrdersInTable();
            foreach (var item in locOrders)
            {
                Console.WriteLine($"\tLocationID => {item.LocationId}-----OrderID => {item.OrderId}-----CustomerID => {item.CustomerId}---");
            }
            Console.WriteLine("This is the order history of this location");
        }

        /// <summary>
        /// this takes a DB context and allows the user to view the oder history of a chosen location.
        /// </summary>
        /// <param name="context"></param>
        public static void CustomerHistory(DBRepository repo)
        {
            //get all customers (as a list) to display 
            var custs = repo.ReadAllCustomers();
            foreach (var item in custs)
            {
                Console.WriteLine($"\tCustomerID => {item.CustID}-----CustomerName => {item.CustomerFirstName} {item.CustomerLastName}");
            }

            //let user choose one by ID
            Console.WriteLine("Please enter the NUMBER of the Customer you'd like to see the order history of.");
            string response = Console.ReadLine();
            int response1 = Convert.ToInt32(response);


            //Search orders for all by that customer
            var ordersByCustId = repo.ReadAllOrdersByCustId(response1);
            //var custOrders = context.Orders.Where(x => x.CustomerId == response1).ToList();
            foreach (var item in ordersByCustId)
            {
                Console.WriteLine($"\tCustomerID => {item.CustomerId}-----OrderID => {item.OrderId}-----LocationID => {item.LocationId}--");
            }
        }

    }
}
