namespace PinewoodTest.Responses
{
    public class CustomerListItemDTO
    {
        public Guid ID { get; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }

        public CustomerListItemDTO(Guid id)
        {
            this.ID = id;
        }
    }
}
