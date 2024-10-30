using MediatR;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class GetAllCustomersCommand : IRequest<IEnumerable<CustomerListItemDTO>>
    {
        // this query normally would have information or pagination etc
        // to keep it simple for this test, it'll return all customers

        public class GetAllCustomersCommandHandler : IRequestHandler<GetAllCustomersCommand, IEnumerable<CustomerListItemDTO>>
        {
            private readonly ICustomerRepository _repository;

            public GetAllCustomersCommandHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }

            public async Task<IEnumerable<CustomerListItemDTO>> Handle(GetAllCustomersCommand request, CancellationToken cancellationToken)
            {
                IEnumerable<Customer> allCustomers = await this._repository.GetAllAsync(cancellationToken);

                return allCustomers.Select(customer => customer.ToListItemDTO());
            }
        }
    }
}
