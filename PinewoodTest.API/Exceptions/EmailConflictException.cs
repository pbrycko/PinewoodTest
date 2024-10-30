namespace PinewoodTest.API
{
    public class EmailConflictException : Exception
    {
        public string Email { get; }
        public Guid ExistingCustomerID { get; }

        public EmailConflictException(string email, Guid existingCustomerID)
            : base($"Email address {email} is already registered for customer ID {existingCustomerID}.")
        {
            this.Email = email;
            this.ExistingCustomerID = existingCustomerID;
        }
    }
}
