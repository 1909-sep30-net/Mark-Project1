using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1_Mark.Models;
//using NLog;

namespace Project1_Mark.Controllers
{
    public class HomeController : Controller
    {

        //create logging variables.
        private readonly ILogger<HomeController> _logger;
        //private static readonly NLog.ILogger s_logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new repository given a data source and instantiates logging
        /// </summary>
        /// <param name="logger">The logger</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /*************************************************************************/


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Logout([FromQuery] int CustomerId, string CustomerFirstName, string CustomerLastName)
        {
            Customer customer = new Customer(CustomerId, CustomerFirstName, CustomerLastName);

            return View("Index");
        }
    }
}
