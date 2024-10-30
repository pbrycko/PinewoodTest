namespace PinewoodTest.Responses
{
    public class CustomerDTO
    {
        public Guid ID { get; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }
        public required string City { get; set; }

        public CustomerDTO(Guid id)
        {
            this.ID = id;
        }
    }
}
