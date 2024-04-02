using Checkout.Controllers;
using CheckoutTest.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CheckoutTest.Test
{
    public class HomeControllerTest
    {    
        [Fact]
        public void Index()
        {
            var mockCheckoutProcess = new Mock<CheckoutProcess>(); 
            var homeController = new HomeController(mockCheckoutProcess.Object);           
            var result = homeController.Index();
           
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(60, viewResult.Model);          
        }
    }
}
