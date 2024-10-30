namespace PinewoodTest.API
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetByIDAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
