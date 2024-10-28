using System.ComponentModel.DataAnnotations;

namespace PinewoodTest.API
{
    public class Customer
    {
        [Key]
        public Guid ID { get; private set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Address { get; set; }
        public required string City { get; set; }
    }
}
