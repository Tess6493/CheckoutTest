using Checkout.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Controllers
{
    public class HomeController : Controller
    {      
        private readonly ICheckoutProcess _checkoutProcess;

        public HomeController(ICheckoutProcess checkoutProcess)
        {           
            _checkoutProcess = checkoutProcess;
        }

        public IActionResult Index()
        {
            // Reset item list
            _checkoutProcess.ResetScannedItems();

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
    }
}
