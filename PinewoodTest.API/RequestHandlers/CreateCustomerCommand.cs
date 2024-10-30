using MediatR;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class CreateCustomerCommand : IRequest<CustomerDTO>
    {
        public required  string FirstName { get; set; } = null!;
        public required string LastName { get; set; } = null!;
                
        public required string Email { get; set; } = null!;
                
        public required string Address { get; set; } = null!;
        public required string City { get; set; } = null!;

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDTO>
        {
            private readonly ICustomerRepository _repository;
            private readonly ILogger _log;

            public CreateCustomerCommandHandler(ICustomerRepository repository, ILogger<CreateCustomerCommandHandler> log)
            {
                _repository = repository;
                _log = log;
            }

            public async Task<CustomerDTO> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                _log.LogDebug("Creating customer {EmailAddress} ({FirstName} {LastName})", request.Email, request.FirstName, request.LastName);

                Customer? existingWithEmail = await _repository.GetByEmailAsync(request.Email, cancellationToken);
                if (existingWithEmail is not null)
                    throw new EmailConflictException(request.Email, existingWithEmail.ID);

                Customer customer = new Customer()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Address = request.Address,
                    City = request.City,
                };

                customer = await _repository.CreateAsync(customer, cancellationToken);

                return customer.ToDTO()!;
            }
        }
    }
}
