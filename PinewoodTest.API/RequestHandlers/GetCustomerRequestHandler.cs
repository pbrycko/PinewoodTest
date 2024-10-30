using MediatR;
using PinewoodTest.Requests;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, CustomerDTO?>
    {
        private readonly ICustomerRepository _repository;

        public GetCustomerRequestHandler(ICustomerRepository repository)
        {
            this._repository = repository;
        }

        public async Task<CustomerDTO?> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer? customer = await this._repository.GetByIDAsync(request.ID, cancellationToken);

            return customer?.ToDTO();
        }
    }
}
