using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PinewoodTest.API.Services
{
    public class PinewoodDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        private readonly IOptions<DatabaseOptions> _options;

        public PinewoodDbContext(IOptions<DatabaseOptions> options)
        {
            this._options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={this._options.Value.SqliteFileName}");
        }
    }
}
