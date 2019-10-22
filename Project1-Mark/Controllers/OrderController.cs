using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using DbLibrary;
using DbLibrary.Entities;
//using DbLibrary.Models;
using DBLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1_Mark.Models;
using Microsoft.Extensions.Logging;
using NLog;

namespace Project1_Mark.Controllers
{
    public class OrderController : Controller
    {
        DBRepository repo;

        //create logging variables.
        private readonly ILogger<OrderController> _logger;
        private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();

        //put the services 
        public OrderController(ILogger<OrderController> logger, DBRepository toContext)//in startup the DBContext was created this will ......something
        {
            this.repo = toContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*************************************************************************/

        // GET: Order/Details/5
        public ActionResult Order([FromQuery] int CustomerId, string CustomerFirstName, string CustomerLastName)
        {
            Customer cust1 = new Customer();
            cust1.CustID = CustomerId;
            cust1.CustomerFirstName = CustomerFirstName;
            cust1.CustomerLastName = CustomerLastName;
            TempData["cust1"] = cust1.CustID;
            var allLocations = repo.ReadAllLocations();//returns a list of locations
            LocationsViewModel lvm = new LocationsViewModel();
            lvm.locationsAll = allLocations.Select(i => i.LocationName);//this

            return View("ViewLocations", lvm);
        }

        // GET: Order/Create
        public ActionResult AddLocation(LocationsViewModel model)
        {
            Location location = new Location();
            location = repo.ReadOneLocation(model.LocationName);//record customers chosen location

            TempData["cust1"] = TempData["cust1"];
            TempData["location"] = location.locID;
            
            var locInventory = repo.ReadLocationInventory(location.LocationName);

            //NOW pre-populate the QuantItems int list for each I.V.M.
            foreach (var item in locInventory)
            {
                for (int i=0; i<=item.ProductQuantity; i++)
                {
                    //item.QuantItems[i] = i;
                }
            }

            //create ViewInventoryViewModels object to send to View.
            ViewInventoryViewModels vivm = new ViewInventoryViewModels();

            //copy over the locInventory
            vivm.InventoriesAll = locInventory.Select(i => new InventoryViewModel 
                { 
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                LocationName = i.LocationName,
                ProductPrice = i.ProductPrice,
                ProductQuantity = i.ProductQuantity
                 });//this


            //add the correct product to each InventoryViewModel iDictionary
            foreach (var item in locInventory)
            {
                //item
            }

            return View("Inventory", vivm);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducts(IFormCollection collection)
        {
            CustomerViewModel cust1 = repo.ReadCustomerById(Convert.ToInt32(TempData["cust1"]));
            var location = repo.ReadLocationById(Convert.ToInt32(TempData["location"]));

            //AddLocation necessary data to the order!
            Order order = new Order();
            order.CustomerID = cust1.CustID;
            order.LocationID = location.locID;

            foreach (var item in collection)
            {
                try//only add the product if the value > 0 !!!
                {
                    if (Convert.ToInt32(item.Value) > 0)
                    {
                        order.itemsOrdered.Add(item.Key, Convert.ToInt32(item.Value));
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("There was an error Adding your order. Please try again.");
                    //s_logger.Info(ex);
                    //return View();
                }
            }

            //add order to the database
            repo.AddOrder(order);

            return View("OrderSuccess", cust1);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}