namespace PinewoodTest.API
{
    public class NotFoundException : Exception
    {
        public Guid CustomerID { get; }

        public NotFoundException(Guid customerID)
            : base($"Customer {customerID} not found.")
        {
            CustomerID = customerID; 
        }
    }
}
