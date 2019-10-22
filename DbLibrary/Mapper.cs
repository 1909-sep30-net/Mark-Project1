using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;
using DbLibrary;
using DbLibrary.Entities;
using Microsoft.Extensions.Logging;
using NLog;

namespace DBLibrary
{
    public class Mapper
    {
        //create logging variables.
        private readonly ILogger<Mapper> _logger;
        private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new repository given a data source and instantiates logging
        /// </summary>
        /// <param name="logger">The logger</param>
        public Mapper(ILogger<Mapper> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*************************************************************************/



        //ENTITY TO CLASS
        public static CustomerViewModel MapCustomer(Customers customer)
        {
            return new CustomerViewModel(customer.CustomerId, customer.CustomerFirstName, customer.CustomerLastName);
        }

        //CLASS TO ENTITY
        public static Customers MapCustomer(Customer customer)
        {
            return new Customers
            {
                CustomerFirstName = customer.CustomerFirstName,
                CustomerLastName = customer.CustomerLastName
            };
        }

        //ENTITY TO CLASS
        //public static Order MapOrder(Orders orders)
        //{//this will return the object/ the lother function will thill have to loop to popoulate the list of products. 
        //    Order ord = new Order(orders.OrderId, orders.LocationId, orders.CustomerId);
            

        //    return ord;
        //}

        //public static Order MapProductsToOrder(Project0Context db, Order order)
        //{
        //    var products = db.ProductsFromOrder
        //        .Include(o => o.ProductName)
        //        .Where()
        //        }

        //CLASS TO ENTITY
        /*        public static Orders MapOrder(Order order)//need to somehow get the product ID for each product
                {
                    //create Orders object to fill the Orders table.
                    Orders ord = new Orders();
                    ord.OrderId = order.OrderID;
                    ord.LocationId = order.LocationID;
                    ord.CustomerId = order.CustomerID;
                    //ProductsFromOrder prods = new ProductsFromOrder();

                    //first copy ordered products into the 
                    foreach (KeyValuePair<string, int> item in order.itemsOrdered)
                    {
                        ProductsFromOrder prods = new ProductsFromOrder();
                        prods.OrderId = order.OrderID;
                        prods.ProductId = ;
                        prods.Quantity = ;
                        prods.Order = item.Key;
                        = item.Value);
                    }

                    //return new Orders
                    //{
                    //    OrderId = order.OrderID,
                    //    CustomerId = order.CustomerID,
                    //    LocationId = order.LocationID,

                    //    ProductsFromOrder = 
                    //};
                }*/

        //ENTITY TO CLASS
        public static Product MapProduct(Products products)
        {//call constructor
            return new Product(products.ProductId, products.ProductName, Convert.ToInt32(products.ProductPrice));
        }

        //CLASS TO ENTITY
        public static Products MapProduct(Product product)
        {//create new product.
            return new Products
            {
                ProductId = product.ProductID,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            };

        }

        //ENTITY TO CLASS
        public static Location MapLocation(Locations locations)
        {
            Location loc = new Location();
            loc.locID = locations.LocationId;
            loc.LocationName = locations.LocationName;

            return loc;
        }

        //CLASS TO ENTITY
        public Locations MapLocation(Location location)
        {
            return new Locations
            {
                LocationName = location.LocationName
            };
        }

        //Map Inventory to InventoryViewModel
        public static InventoryViewModel MapInventory(Inventory i)
        {
            InventoryViewModel inv = new InventoryViewModel();

            inv.ProductId = i.ProductId;
            inv.ProductPrice = i.ProductPrice;
            inv.ProductQuantity = i.ProductQuantity;
            inv.LocationName = i.LocationName;

            return inv;
        }

    }
}
