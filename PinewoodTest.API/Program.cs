using PinewoodTest.API.Middlewares;
using PinewoodTest.API.Services;

namespace PinewoodTest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureOptions(builder.Services, builder.Configuration);
            ConfigureServices(builder.Services);

            WebApplication app = builder.Build();
            ConfigureRequestPipeline(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining<Program>());

            services.AddDbContext<PinewoodDbContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        private static void ConfigureOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(configuration.GetSection("Database"));
        }

        private static void ConfigureRequestPipeline(WebApplication app)
        {
            // this CORS is not secure, but for this test is okay
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());  

            app.UseMiddleware<CustomValidationExceptionMiddleware>();
            app.MapControllers();
        }
    }
}
