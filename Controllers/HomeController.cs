using Checkout.Interfaces;
using Checkout.Models;
using CheckoutTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Checkout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICheckoutProcess _checkoutProcess;

        public HomeController(ILogger<HomeController> logger, ICheckoutProcess checkoutProcess)
        {
            _logger = logger;
            _checkoutProcess = checkoutProcess;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCost()
        {
            _checkoutProcess.Reset();
            // Scan items
            _checkoutProcess.Scan("A");
            _checkoutProcess.Scan("A");
            _checkoutProcess.Scan("A");
            _checkoutProcess.Scan("B");
            _checkoutProcess.Scan("B");
            _checkoutProcess.Scan("F");
            _checkoutProcess.Scan("F");

            // Calculate total price
            int totalPrice = _checkoutProcess.GetTotalPrice();
            return View("Index", totalPrice);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
