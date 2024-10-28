using MediatR;
using PinewoodTest.Requests;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class GetAllCustomersRequestHandler : IRequestHandler<GetAllCustomersRequest, IEnumerable<CustomerListItemDTO>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersRequestHandler(ICustomerRepository repository)
        {
            this._repository = repository;
        }

        public async Task<IEnumerable<CustomerListItemDTO>> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<Customer> allCustomers = await this._repository.GetAllAsync(cancellationToken);
            
            return allCustomers.Select(customer => customer.ToListItemDTO());
        }
    }
}
