using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using DbLibrary;
using DBLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1_Mark.Models;

namespace Project1_Mark.Controllers
{
    public class LoginController : Controller
    {

        DBRepository repo;
        //put the services 
        public LoginController(DBRepository toContext)//in startup the DBContext was created this will 
        {
            this.repo = toContext; 
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Login([FromQuery] string CustomerFirstName, string CustomerLastName)
        {
            //get the info sent from the form
            Customer customer = new Customer( CustomerFirstName, CustomerLastName );
            CustomerViewModel cust1 = repo.ReadCustomer(customer);
            
            if(cust1 == null)
            {//this renders the index page again.
                return View("error", new ErrorViewModel {errorMsg = $"{CustomerFirstName} {CustomerLastName} was not found. Please try again." });
            }

            //if successful, render page to choose to order or search stuff.
            return View("SearchOrOrder", cust1);
        }


        // GET: Login/Create
        public ActionResult Register([FromQuery] string CustomerFirstName, string CustomerLastName)
        {
            Customer customer = new Customer(CustomerFirstName, CustomerLastName);

            CustomerViewModel cust1 = repo.AddCustomer(customer);
            if (cust1 == null)
            {//this renders the index page again.
                return View("error", new ErrorViewModel { errorMsg = $"{CustomerFirstName} {CustomerLastName} was not found. Please try again." });
            }
            return View("SearchOrOrder", cust1);
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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