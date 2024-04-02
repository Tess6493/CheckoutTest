using Checkout.Interfaces;
using Checkout.Models;

namespace CheckoutTest.Service
{
    public class CheckoutProcess : ICheckoutProcess
    {
        /// <summary>
        /// List of possible products
        /// </summary>
        private List<Product> ProductList = new List<Product>()
        {
            new Product() { Code = "A", Price = 10, MultipurchaseReq = 3, MultipurchasePrice = 25 },
            new Product() { Code = "B", Price = 12, MultipurchaseReq = 2, MultipurchasePrice = 20 },
            new Product() { Code = "C", Price = 15 },
            new Product() { Code = "D", Price = 25 },
            new Product() { Code = "F", Price = 8, MultipurchaseReq = 2, MultipurchasePrice = 15 }
        };

        /// <summary>
        /// Current items scanned
        /// </summary>
        private List<string> scannedItems = new List<string>();

        /// <summary>
        /// Reset the scanned item list
        /// </summary>
        public void ResetScannedItems()
        {
            scannedItems.Clear();
        }

        /// <summary>
        /// Make sure item exists and add it to scanned items
        /// </summary>
        /// <param name="product">Code of the product</param>
        public void Scan(string productCode)
        {
            if (ProductList.Exists(s => s.Code == productCode))
            {
                scannedItems.Add(productCode);
            }
            else
            {
                throw new ArgumentException("Invalid service code.");
            }
        }

        /// <summary>
        /// Work out best pricing for product range
        /// </summary>
        /// <returns>total price of products</returns>
        public int GetTotalPrice()
        {
            int totalPrice = 0;

            foreach (var item in scannedItems.Distinct())
            {
                // Get the quantity
                int quantity = scannedItems.Where(m => m == item).Count();

                // Find the product
                Product product = ProductList.First(s => s.Code == item);

                // If the multipurchase requirement exists, and the quantity exceeds it
                if (product.MultipurchaseReq > 0 && quantity >= product.MultipurchaseReq)
                {
                    int multiBuys = quantity / product.MultipurchaseReq;
                    int remainingItems = quantity % product.MultipurchaseReq;

                    totalPrice += multiBuys * product.MultipurchasePrice;
                    totalPrice += remainingItems * product.Price;
                }
                else
                {
                    totalPrice += quantity * product.Price;
                }
            }
            return totalPrice;
        }
    }
}
