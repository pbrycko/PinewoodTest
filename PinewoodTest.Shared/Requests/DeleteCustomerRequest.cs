using MediatR;

namespace PinewoodTest.Requests
{
    public class DeleteCustomerRequest : IRequest
    {
        public Guid ID { get; }

        public DeleteCustomerRequest(Guid id)
        {
            this.ID = id;
        }
    }
}
