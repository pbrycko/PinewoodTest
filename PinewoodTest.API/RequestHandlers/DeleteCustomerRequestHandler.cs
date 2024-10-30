using MediatR;
using PinewoodTest.Requests;

namespace PinewoodTest.API.RequestHandlers
{
    public class DeleteCustomerRequestHandler : IRequestHandler<DeleteCustomerRequest>
    {
        private readonly ICustomerRepository _repository;

        public DeleteCustomerRequestHandler(ICustomerRepository repository)
        {
            this._repository = repository;
        }

        public async Task Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            Customer? customer = await this._repository.GetByIDAsync(request.ID, cancellationToken);
            if (customer is null)
                throw new NotFoundException(request.ID);

            await this._repository.DeleteAsync(customer, cancellationToken);
        }
    }
}
