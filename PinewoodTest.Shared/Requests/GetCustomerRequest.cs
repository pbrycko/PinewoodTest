using MediatR;
using PinewoodTest.Responses;

namespace PinewoodTest.Requests
{
    public class GetCustomerRequest : IRequest<CustomerDTO>
    {
        public Guid ID { get; }

        public GetCustomerRequest(Guid id)
        {
            this.ID = id;
        }
    }
}
