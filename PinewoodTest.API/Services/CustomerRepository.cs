using Microsoft.EntityFrameworkCore;

namespace PinewoodTest.API.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PinewoodDbContext _databaseContext;
        private readonly ILogger _log;

        public CustomerRepository(PinewoodDbContext databaseContext, ILogger<CustomerRepository> log)
        {
            _databaseContext = databaseContext;
            _log = log;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            _log.LogTrace("Getting all customers from the DB");
            return await _databaseContext.Customers.ToListAsync(cancellationToken);
        }

        public async Task<Customer?> GetByIDAsync(Guid id, CancellationToken cancellationToken = default)
        {
            _log.LogTrace("Getting customer from the DB by ID {ID}", id);
            return await _databaseContext.Customers.FirstOrDefaultAsync(customer => customer.ID == id, cancellationToken);
        }

        public async Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            _log.LogTrace("Getting customer from the DB by Email {Email}", email);
            return await _databaseContext.Customers.FirstOrDefaultAsync(customer => customer.Email == email, cancellationToken);
        }

        public async Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _log.LogTrace("Inserting customer {EmailAddress} ({FirstName} {LastName}) to the DB", customer.Email, customer.FirstName, customer.LastName);
            
            await _databaseContext.Customers.AddAsync(customer, cancellationToken);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _log.LogTrace("Updating customer {ID} in the DB", customer.ID);

            _databaseContext.Customers.Update(customer);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return customer;
        }

        public async Task DeleteAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _log.LogTrace("Deleting customer {ID} from the DB", customer.ID);
            _databaseContext.Remove(customer);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}
