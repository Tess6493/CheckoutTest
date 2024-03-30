namespace Checkout.Interfaces
{
    public interface ICheckoutProcess
    {
        void Scan(string service);
        int GetTotalPrice();
        void Reset();
    }
}
