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
using Microsoft.Extensions.Logging;
using NLog;

namespace Project1_Mark.Controllers
{
    public class LoginController : Controller
    {
        //create logging variables.
        private readonly ILogger<LoginController> _logger;
        private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();
        DBRepository repo;


        /// <summary>
        /// Initializes a new repository given a data source and instantiates logging
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="toContext"></param>
        public LoginController(ILogger<LoginController> logger, DBRepository toContext)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.repo = toContext;
        }


        /*************************************************************************/

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

        public ActionResult LogOut()
        {
            SignOut();
            //Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("index", "Home");
        }
    }
}