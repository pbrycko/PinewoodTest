using MediatR;

namespace PinewoodTest.API.RequestHandlers
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid ID { get; }

        public DeleteCustomerCommand(Guid id)
        {
            ID = id;
        }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
        {
            private readonly ICustomerRepository _repository;

            public DeleteCustomerCommandHandler(ICustomerRepository repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _repository.GetByIDAsync(request.ID, cancellationToken);
                if (customer is null)
                    throw new NotFoundException(request.ID);

                await _repository.DeleteAsync(customer, cancellationToken);
            }
        }
    }
}
