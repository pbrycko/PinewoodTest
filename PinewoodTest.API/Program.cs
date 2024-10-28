namespace PinewoodTest.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services);

            WebApplication app = builder.Build();
            ConfigureRequestPipeline(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        private static void ConfigureRequestPipeline(WebApplication app)
        {
            app.MapControllers();
        }
    }
}
