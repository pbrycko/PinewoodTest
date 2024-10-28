namespace PinewoodTest.API
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
