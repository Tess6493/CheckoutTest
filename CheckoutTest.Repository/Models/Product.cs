namespace Checkout.Models
{
    public class Product
    {
        public string Code { get; set; } = "";
        public int Price { get; set; }
        public int MultipurchaseReq { get; set; }
        public int MultipurchasePrice { get; set; }
    }
}
