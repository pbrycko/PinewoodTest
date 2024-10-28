using Microsoft.EntityFrameworkCore;

namespace PinewoodTest.API.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PinewoodDbContext _databaseContext;
        private readonly ILogger _log;

        public CustomerRepository(PinewoodDbContext databaseContext, ILogger<CustomerRepository> log)
        {
            this._databaseContext = databaseContext;
            this._log = log;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            this._log.LogTrace("Getting all customers from the DB");
            return await this._databaseContext.Customers.ToListAsync(cancellationToken);
        }

        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            this._log.LogTrace("Inserting customer {EmailAddress} ({FirstName} {LastName}) to the DB", customer.Email, customer.FirstName, customer.LastName);
            
            await this._databaseContext.Customers.AddAsync(customer, cancellationToken);
            await this._databaseContext.SaveChangesAsync(cancellationToken);

            return customer;
        }
    }
}
