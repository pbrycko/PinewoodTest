using MediatR;

namespace PinewoodTest.API.RequestHandlers
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid ID { get; }

        public DeleteCustomerCommand(Guid id)
        {
            this.ID = id;
        }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
        {
            private readonly ICustomerRepository _repository;

            public DeleteCustomerCommandHandler(ICustomerRepository repository)
            {
                this._repository = repository;
            }

            public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await this._repository.GetByIDAsync(request.ID, cancellationToken);
                if (customer is null)
                    throw new NotFoundException(request.ID);

                await this._repository.DeleteAsync(customer, cancellationToken);
            }
        }
    }
}
