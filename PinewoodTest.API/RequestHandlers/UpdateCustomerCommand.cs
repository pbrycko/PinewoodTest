using MediatR;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class UpdateCustomerCommand : IRequest<CustomerDTO>
    {
        public Guid ID { get; }

        public required string FirstName { get; set; } = null!;
        public required string LastName { get; set; } = null!;

        public required string Email { get; set; } = null!;

        public required string Address { get; set; } = null!;
        public required string City { get; set; } = null!;

        public UpdateCustomerCommand(Guid id)
        {
            this.ID = id;
        }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDTO>
        {
            private readonly ICustomerRepository _repository;
            private readonly ILogger _log;

            public UpdateCustomerCommandHandler(ICustomerRepository repository, ILogger<UpdateCustomerCommandHandler> log)
            {
                this._repository = repository;
                this._log = log;
            }

            public async Task<CustomerDTO> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                this._log.LogDebug("Updating customer {ID}", request.ID);

                Customer? customer = await this._repository.GetByIDAsync(request.ID, cancellationToken);
                if (customer is null)
                    throw new NotFoundException(request.ID);

                if (request.Email != customer.Email)
                {
                    Customer? existingWithEmail = await this._repository.GetByEmailAsync(request.Email, cancellationToken);
                    if (existingWithEmail is not null)
                        throw new EmailConflictException(request.Email, existingWithEmail.ID);
                }

                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.Email = request.Email;
                customer.Address = request.Address;
                customer.City = request.City;

                customer = await this._repository.UpdateAsync(customer, cancellationToken);

                return customer.ToDTO()!;
            }
        }
    }
}
