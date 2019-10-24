﻿//TEST COMMIT
// Entity Framework Core
// database-first approach steps...
/*
 * 1. have a data access library project separate from the startup application project.
 *    (with a project reference from the latter to the former).
 * 2. install Microsoft.EntityFrameworkCore.Design and Microsoft.EntityFrameworkCore.SqlServer
 *    to both projects.
 * 3. using Git Bash / terminal, from the data access project folder run..without braces.
 * [dotnet ef dbcontext scaffold "Server=tcp:mooremark.database.windows.net,1433;Initial Catalog=Project0;Persist Security Info=False;User ID=mark.c.moore@hotmail.com@mooremark.database.windows.net;Password=cU5tod33qUal;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer --startup-project ../mark-project0 --force --output-dir Entities]

 *    https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet#dotnet-ef-dbcontext-scaffold
 *    (if you don't have dotnet ef installed, run: "dotnet tool install --global dotnet-ef")
 *    (this will fail if your projects do not compile)
 * 4. delete the DbContext.OnConfiguring method from the scaffolded code.
 *    (so that the connection string is not put on the public internet)
 * 5. any time you change the structure of the tables (DDL), go to step 3.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using DbLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DbLibrary;
//using Project1_Mark.Models;

namespace DBLibrary
{
    public class DBRepository
    {
        private readonly Project0Context _dbContext;
        private readonly ILogger<Project0Context> _logger;

        /// <summary>
        /// Initializes a new restaurant repository given a suitable restaurant data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public DBRepository(Project0Context dbContext, ILogger<Project0Context> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /*************************************************************************/

        /**************************************
        * INVENTORY FUNCTIONS BELOW
        * ************************************/
        /// <summary>
        /// this method takes a location name and returns a List of InventoryViewModel objects
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locationName"></param>
        /// <returns>List<Products> </returns>
        public List<InventoryViewModel> ReadLocationInventory(string locationName)
        {
            //find all the products for that location
            var inventory = _dbContext.Inventory
                .Where(i => i.LocationName == locationName).ToList();

            //Make a list to hold mapped InventoryViewModels
            List<InventoryViewModel> invList = new List<InventoryViewModel>();

            //In LOOP, send to Mapper to change the Inventory list to a InventoryViewModel List.
            foreach (Inventory item in inventory)
            {
                InventoryViewModel inv = Mapper.MapInventory(item); //convert to InventoryViewModel
                inv.ProductName = GetProdNameById(item.ProductId);  //Add product name
                invList.Add(inv);                                   //append to List to return to OrderController
            }
            return invList;
        }

        /**************************************
         * PRODUCT FUNCTIONS BELOW
         * ************************************/

        ///<summary>
        ///returns a list of all the Products
        ///</summary>
        ///
        public List<Products> ReadAllProducts()
        {
            return _dbContext.Products.ToList();                                                   ///NEED TO MAP
        }

        public Product ReadProductById(Project0Context context, int prodId)
        {
            var prod = context.Products
                .Where(x => x.ProductId == prodId).First();

            return Mapper.MapProduct(prod);
        }

        ///<summary>
        ///takes a context and returns a List of Locations
        ///</summary>
        public List<Locations> ReadAllLocations()
        {
            return _dbContext.Locations.ToList();//NEED TO MAP THESE
        }

        /// <summary>
        ///takes a location ID and returns the Location object
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locNum"></param>
        /// <returns>Location object</returns>
        public Location ReadLocationById(int locNum)
        {
            var loc = _dbContext.Locations
                .Where(x => x.LocationId == locNum)
                .First();

            if (loc == null)
            {
                _logger.LogInformation("User unfound in DB");
                throw new NullReferenceException("That location does not exist. Please try again.");
            }
            return Mapper.MapLocation(loc);
        }

        ///<summary>
        ///This option not required at this time
        ///</summary>
        public Location ReadOneLocation(string location)
        {
            //find the location information
            var loc = _dbContext.Locations
                .Where(x => x.LocationName == location).FirstOrDefault();

            //Map and return
            return Mapper.MapLocation(loc);
        }

        /**************************************
         * CUSTOMER FUNCTIONS BELOW
         * *************************************/

        ///<summary>
        ///takes a context and Customer. Returns a true bool to indicate insertion was successfull
        /// </summary>
        public CustomerViewModel AddCustomer(Customer customer)
        {
            //check of the context has the customer by name
            if (!(_dbContext.Customers.Any(c => c.CustomerFirstName == customer.CustomerFirstName && c.CustomerLastName == customer.CustomerLastName)))
            { 
                //if customer is NOT found,,, add the customer
                Customers entity = Mapper.MapCustomer(customer);
                _dbContext.Customers.Add(entity);//maybe the context still has the first wrong Customer?
            }
            else
            {
                Console.WriteLine("\tThere is already an account with that name.\n\tPlease try again with a different name.");
                return null;
            }

            try
            { //save changes
                _dbContext.SaveChanges(); 
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("There was an error Adding your account. Please try again with a different name.");
                _logger.LogError(ex, "Unable to update DB at {time}", DateTime.UtcNow );
                return null;
            }

            //no errors till now so send the same name into Read Customer to get the new customer from the DB
            return ReadCustomer(customer); 
        }

        ///<summary>
        ///This method takes as context and the verified customer info from main and inserts it into the DB
        ///Returns the customer from the DB
        ///</summary>
        public CustomerViewModel ReadCustomer(Customer customer)
        {
            var result = _dbContext.Customers
                .Where(c => c.CustomerFirstName == customer.CustomerFirstName && c.CustomerLastName == customer.CustomerLastName)
                .FirstOrDefault();

            if (result == null)
            {
                Console.WriteLine("Sorry, That customer was not found.");
                return null;
            }
            var result1 = Mapper.MapCustomer(result);
            return result1;
        }

        public CustomerViewModel ReadCustomerById(int custId)
        {
            var result = _dbContext.Customers
                .Where(c => c.CustomerId == custId)
                .FirstOrDefault();

            if (result == null)
            {
                Console.WriteLine("Sorry, That customer was not found.");
                _logger.LogInformation("Unable to find user by ID in DB at {time}", DateTime.UtcNow);
                return null;
            }
            var result1 = Mapper.MapCustomer(result);
            return result1;
        }

        public List<CustomerViewModel> ReadAllCustomers()
        {
            var result = _dbContext.Customers;              //get all the Customers

            if (result == null)
            {
                Console.WriteLine("Sorry, Unable to find all customers.");
                _logger.LogInformation("Unable to find all customers in DB at {time}", DateTime.UtcNow);
                return null;
            }

            List<CustomerViewModel> custs = new List<CustomerViewModel>();    //create a list of Customer objects
            foreach (var item in result)                    //map each Customers to a Customer
            {
                custs.Add(Mapper.MapCustomer(item));
            }

            return custs;
        }

        /**************************************
         * ORDER FUNCTIONS BELOW
         * *************************************/

        ///<summary>
        ///This option takes a DB context and an order object and inserts it into the DB
        ///</summary>
        public void AddOrder(Order order)
        {
            //make an EF-Friendly Orders object
            Orders orders = new Orders();
            orders.CustomerId = order.CustomerID;
            orders.LocationId = order.LocationID;
            orders.OrderId = order.OrderID;

            foreach (var item in order.itemsOrdered)
            {
                //make ProductsFromOrder object for each product
                ProductsFromOrder prodsInsert = new ProductsFromOrder();
                prodsInsert.OrderId = order.OrderID;
                prodsInsert.Quantity = item.Value;
                prodsInsert.ProductId = _dbContext.Products
                    .Where(x => x.ProductName == item.Key)
                    .Select(x => x.ProductId)
                    .First();

                orders.ProductsFromOrder.Add(prodsInsert);
            }
            _dbContext.Add(orders);
            _dbContext.SaveChanges();

            var success = DecreaseInventory(order);

            if(success == false)
            {
                throw new Exception("There was an error updating the DB. Don't worry. Your order was placed successfully.");
            }
        }

        private bool DecreaseInventory(Order order)
        {
            //get the location name based on the locId 
            var loc = _dbContext.Locations
                .Where(x => x.LocationId == order.LocationID).FirstOrDefault();

            foreach (var item in order.itemsOrdered)
            {
                //get the product ID based on the product name.
                var prodId = _dbContext.Products
                    .Where(x => x.ProductName == item.Key).FirstOrDefault();

                //locate the product in inventory based on LocationName and ProductId
                var ord = _dbContext.Inventory
                    .Where(x => x.LocationName == loc.LocationName && x.ProductId == prodId.ProductId)
                    .FirstOrDefault();

                try
                {
                    //decrease the quantity of the product in inventory
                    ord.ProductQuantity -= item.Value;
                    _dbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("There was an error Adding your order. Please try again.");
                    _logger.LogInformation(ex, "Unable to save DecreaseInventory changes to DB");

                }
            }
            return true;
        }

        ///<summary>
        ///This option will take the details of an order inputted by the user and searches for a matching order. 
        ///Then returns the order to main for display
        ///</summary>
        public Order ReadOrderByOrderId(int ID)
        {
            var order1 = _dbContext.Orders
                .Where(x => x.OrderId == ID)
                .First();

                //create an Order obj and populate itwith custID OrderID LocID
                Order custsOrder = new Order();
                custsOrder.CustomerID = order1.CustomerId;
                custsOrder.LocationID = order1.LocationId;
                custsOrder.OrderID = order1.OrderId;

                //get products based on the orderID
                var prods1 = _dbContext.ProductsFromOrder
                    .Where(x => x.OrderId == ID)
                    .ToList();

                foreach (var x in prods1)
                {
                    custsOrder.itemsOrdered.Add(GetProdNameById(x.ProductId), x.Quantity);
                }

                return custsOrder;
        }

        public string GetProdNameById(int prodID)
        {
            var name = _dbContext.Products
                .Where(x => x.ProductId == prodID).First();

            return name.ProductName;
        }

        ///<summary>
        ///this takes a DB context and returns a List of all orders
        ///</summary>
        public List<Orders> ReadAllOrdersInTable()
        {
            return _dbContext.Orders.ToList();//NEED TO MAP!
        }

        public List<Orders> ReadAllOrdersByLocationId(int locId)
        {
            var orders = _dbContext.Orders.Where(x => x.LocationId == locId).ToList();
            return orders;
        }


        ///<summary>
        ///takes a customers ID and returns a list of teh order details of that customer
        ///</summary>
        public List<Orders> ReadAllOrdersByCustId(int CustomerId)
        {
            var custOrders = _dbContext.Orders.Where(x => x.CustomerId == CustomerId).ToList();
            return custOrders;
        }
    }
}
