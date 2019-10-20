using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1_Mark.Controllers
{
    public class SearchController : Controller
    {

        // GET: Search/Details/5
        public ActionResult Search(int id)
        {
            string userType;
            //menu to choose which search to do
            do
            {
                Console.WriteLine("\n Would you like to search for display details of an order. " +
                "display all order history of a store location, " +
                "or display all order history of a customer, ");

                Console.WriteLine("\n\n\tA - Find details of an order.\n\tB - Display the history of a location.\n\tC - Display a customers order history.");
                userType = Console.ReadLine();
                userType = userType.ToUpper();  //to accept upper and lower case letters.
            } while (!(userType.Equals("A") || userType.Equals("B") || userType.Equals("C")));

            switch (userType)
            {
                case "A":
                    OrderDetails(context);
                    break;
                case "B":
                    LocationHistory(context);
                    break;
                case "C":
                    CustomerHistory(context);
                    break;
            }


            return View();
        }

        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
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

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
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

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
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