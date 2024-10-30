using PinewoodTest.Responses;

namespace PinewoodTest.Client
{
    public static class LinkBuilder
    {
        public static string GetCustomerLink(Guid id)
            => $"/customers/{id}";

        public static string GetCustomerLink(CustomerDTO customer)
            => GetCustomerLink(customer.ID);

        public static string GetCustomerLink(CustomerListItemDTO customer)
            => GetCustomerLink(customer.ID);
    }
}
