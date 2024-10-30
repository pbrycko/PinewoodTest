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

        public static CustomerDTO? ToDTO(this Customer customer)
        {
            if (customer == null) 
                return null;

            return new CustomerDTO(customer.ID)
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Address = customer.Address,
                City = customer.City,
            };
        }
    }
}
