using MediatR;
using PinewoodTest.Responses;

namespace PinewoodTest.Requests
{
    public class GetAllCustomersRequest : IRequest<IEnumerable<CustomerListItemDTO>>
    {
        // this query normally would have information or pagination etc
        // to keep it simple for this test, it'll return all customers, and it's just a marker request class for MediatR
    }
}
