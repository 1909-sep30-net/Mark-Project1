using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary1;
using DbLibrary;
using DbLibrary.Entities;
using DBLibrary;
using Project1_Mark.Models;
using Microsoft.Extensions.Logging;
using NLog;

namespace Project1_Mark.Controllers
{
    public class SearchController : Controller
    {
        DBRepository repo;

        //create logging variables.
        private readonly ILogger<SearchController> _logger;
        private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();

        //put the services 
        public SearchController(ILogger<SearchController> logger, DBRepository toContext)//in startup the DBContext was created this will ......something
        {
            this.repo = toContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*************************************************************************/

        // GET: Search/Details/5
        public ActionResult Search(int id)
        {
            return View("searchChoices");
        }

        public ActionResult GetOrderDetails()
        {
            var orders = repo.ReadAllOrdersInTable();

            return View("ViewOrders", orders);
        }

        public ActionResult Details(int id)
        {
            Order order1 = repo.ReadOrderByOrderId(id);


            return View("OrderDetails1", order1);
        }

        public ActionResult GetLocationHistory()
        {
            //get all the locations to list them

            var locations = repo.ReadAllLocations();


            return View("ListLocations", locations);
        }

        public ActionResult LocHistory(int id)
        {
            //get all the locations to list them
            var locations = repo.ReadAllOrdersByLocationId(id);
           
            return View("OrdersByLocation", locations);
        }

        public ActionResult GetCustomerHistory()
        {
            //get all the customers to list them

            var customers = repo.ReadAllCustomers();


            return View("ListAllCustomers", customers);
        }

        public ActionResult CustDetails(int id)
        {
            //get all the customers to list them
            var customerDetails = repo.ReadAllOrdersByCustId(id);


            return View("CustomerDetails", customerDetails);
        }
    }
}