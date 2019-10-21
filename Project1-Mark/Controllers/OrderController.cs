using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using DbLibrary;
using DbLibrary.Entities;
using DBLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1_Mark.Models;

namespace Project1_Mark.Controllers
{
    public class OrderController : Controller
    {
        DBRepository repo;
        Customer customer;
        Location location;
        Order order;
        //put the services 
        public OrderController(DBRepository toContext)//in startup the DBContext was created this will ......something
        {
            this.repo = toContext;
        }

        // GET: Order/Details/5
        public ActionResult Order([FromQuery] int CustomerId, string CustomerFirstName, string CustomerLastName)
        {
            Customer cust1 = new Customer();
            cust1.CustID = CustomerId;
            cust1.CustomerFirstName = CustomerFirstName;
            cust1.CustomerLastName = CustomerLastName;
            customer = cust1;
            var allLocations = repo.ReadAllLocations();//returns a list of locations
            LocationsViewModel lvm = new LocationsViewModel();
            foreach (var item in allLocations)
            {
                lvm.locationsAll.Add(item);
            }
            return View("ViewLocations", lvm);
        }

        // GET: Order/Create
        public ActionResult AddLocation(LocationsViewModel model)
        {
            Location loc = new Location();



            this.location = loc;
            var locInventory = repo.ReadLocationInventory(this.location.LocationName);

            //NOW get all the products to add the correct product to each InventoryViewModel


            return View("Inventory", locInventory);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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