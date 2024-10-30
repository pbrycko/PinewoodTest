using System.ComponentModel.DataAnnotations;

namespace PinewoodTest.Requests
{
    public class CreateCustomerRequest
    {
        [Required, MinLength(2), MaxLength(64)]
        public string FirstName { get; set; } = null!;
        [Required, MinLength(2), MaxLength(64)]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required, MinLength(8), MaxLength(512)]
        public string Address { get; set; } = null!;
        [Required, MinLength(2), MaxLength(32)]
        public string City { get; set; } = null!;
    }
}
