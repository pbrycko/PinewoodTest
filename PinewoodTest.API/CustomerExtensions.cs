using PinewoodTest.Responses;

namespace PinewoodTest.API
{
    public static class CustomerExtensions
    {
        public static CustomerListItemDTO ToListItemDTO(this Customer customer)
        {
            return new CustomerListItemDTO(customer.ID)
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }
    }
}
