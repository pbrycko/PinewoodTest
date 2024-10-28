namespace PinewoodTest.API
{
    public class Customer
    {
        public Guid Id { get; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }
        public required string City { get; set; }

        public Customer(Guid id)
        {
            this.Id = id;
        }
    }
}
