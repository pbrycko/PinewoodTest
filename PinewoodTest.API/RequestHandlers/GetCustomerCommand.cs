using MediatR;
using PinewoodTest.Responses;

namespace PinewoodTest.API.RequestHandlers
{
    public class GetCustomerCommand : IRequest<CustomerDTO>
    {
        public Guid ID { get; }

        public GetCustomerCommand(Guid id)
        {
            ID = id;
        }

        public class GetCustomerCommandHandler : IRequestHandler<GetCustomerCommand, CustomerDTO?>
        {
            private readonly ICustomerRepository _repository;

            public GetCustomerCommandHandler(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task<CustomerDTO?> Handle(GetCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _repository.GetByIDAsync(request.ID, cancellationToken);

                return customer?.ToDTO();
            }
        }
    }
}
