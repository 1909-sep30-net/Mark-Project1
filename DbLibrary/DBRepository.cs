//TEST COMMIT
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
using NLog;
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

        //don't know if this is necessary....
        private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();
        /**************************************
        * INVENTORY FUNCTIONS BELOW
        * ************************************/
        /// <summary>
        /// this method takes the context and location name and returns a List of Inventory objects in 
        /// that locations inventory.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="locationName"></param>
        /// <returns>List<Products> </returns>
        public List<Inventory> ReadLocationInventory(string locationName)
        {
            //find all the products for that location
            var result = _dbContext.Inventory
                .Where(i => i.LocationName == locationName).ToList();
            return result;
        }

        /**************************************
         * PRODUCT FUNCTIONS BELOW
         * ************************************/

 /*       public static void AddProduct(Product product)
        {
            //remember to save.
            Products prods = Mapper.MapProduct();
        }*/

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static int AddProduct(Products product)
        //{
        //    using (var db = new Project0Context())
        //    {
        //        Console.WriteLine("Inserting a new product");
        //        db.Add(product);
        //        //db.Add(new Products
        //        //{
        //        //    ProductName = "mango",
        //        //    ProductPrice = 1234
        //        //});
        //        db.SaveChanges();
        //        //products.Add(product);
        //        return 1;
        //    }
        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static Products ReadProduct(Products product)
        //{
        //    //find the product in the array
        //    using (var db = new Project0Context())
        //    {
        //        Console.WriteLine("Reading a product");
        //        var prod = db.Products.Find(2);
        //        return prod;
        //    }
        //}

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
        ///This option not required at this time
        ///</summary>
        //public static List<Product> UpdateProduct(Project0Context context, Product product)
        //{
        //    //find then update the product
        //    return products;
        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static List<Product> DeleteProduct(List<Product> products, Product product)
        //{
        //    return products;
        //}


        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static Product SearchProducts(Product product)
        //{
        //    return product;
        //}

        /**************************************
         * LOCATION FUNCTIONS BELOW
         * *************************************/

        //public static int AddLocation(Location location)
        //{
        //    using (var db = new Project0Context())
        //    {
        //        Console.WriteLine("Inserting a new product");
        //        db.Add(location);
        //        //db.Add(new Products
        //        //{
        //        //    ProductName = "apple",
        //        //    ProductPrice = 1234
        //        //});
        //        db.SaveChanges();
        //        //products.Add(product);
        //        return 1;
        //        //locations.Add(location);
        //        //return locations;
        //    }
        //}

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
                throw new NullReferenceException("That location does not exist. Please try again.");
            }

            return Mapper.MapLocation(loc);
        }

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static bool ReadOneLocation(Project0Context context, int location)//this might be accomplished with SearchLocations() below
        //{
        //    if()
        //    return true;
        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static void UpdateLocation(Location location)
        //{

        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static void DeleteLocation(Location location)
        //{

        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static Location SearchLocations(Location location)
        //{
        //    return location;
        //}

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
                s_logger.Info(ex);
                return null;
            }

            //no errors till now so send the same name into Read Customer to get the new customer from the DB
            return ReadCustomer(customer); 
        }

        ///<summary>
        ///This method takes as context and the verified customer info from main and inserts it into the DB
        ///Returns the customer from the DB
        ///</summary>
        /*        public Customer ReadCustomer(Customer customer)
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
                }*/

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

        public List<CustomerViewModel> ReadAllCustomers()
        {
            var result = _dbContext.Customers;              //get all the Customers
            List<CustomerViewModel> custs = new List<CustomerViewModel>();    //create a list of Customer objects
            foreach (var item in result)                    //map each Customers to a Customer
            {
                custs.Add(Mapper.MapCustomer(item));
            }

            return custs;
        }

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static List<Customer> ReadAllCustomers()
        //{
        //    return customers;
        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static List<Customer> UpdateCustomer(List<Customer> Customers, Customer customer)
        //{
        //    return Customers;
        //}

        ///<summary>
        ///This option not required at this time 
        ///</summary>
        //public static List<Customer> DeleteCustomer(List<Customer> Customers, Customer customer)
        //{
        //    //Customers.Find(customer);//find out how to find and delete from a list.
        //    return Customers;
        //}

        /**************************************
         * ORDER FUNCTIONS BELOW
         * *************************************/

        ///<summary>
        ///This option takes a DB context and an order object and inserts it into the DB
        ///</summary>
        public void AddOrder(Order order)
        {
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


        ///<summary>
        ///takes a customers ID and returns a list of teh order details of that customer
        ///</summary>
        public List<Orders> ReadAllOrdersByCustId(int CustomerId)
        {
            var custOrders = _dbContext.Orders.Where(x => x.CustomerId == CustomerId).ToList();
            return custOrders;
        }

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static List<Order> UpdateOrder(List<Order> orders, Order order)
        //{
        //    return orders;
        //}

        ///<summary>
        ///This option not required at this time
        ///</summary>
        //public static List<Order> DeleteOrder(List<Order> orders, Order order)
        //{
        //    return orders;
        //}
    }
}
