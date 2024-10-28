using MediatR;
using PinewoodTest.Requests;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class CreateCustomerRequestHandler : IRequestHandler<CreateCustomerRequest, CustomerListItemDTO>
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger _log;

        public CreateCustomerRequestHandler(ICustomerRepository repository, ILogger<CreateCustomerRequestHandler> log)
        {
            this._repository = repository;
            this._log = log;
        }

        public async Task<CustomerListItemDTO> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            this._log.LogDebug("Creating customer {EmailAddress} ({FirstName} {LastName})", request.Email, request.FirstName, request.LastName);

            Customer customer = new Customer()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Address = request.Address,
                City = request.City,
            };

            customer = await this._repository.CreateAsync(customer);

            return customer.ToListItemDTO();
        }
    }
}
