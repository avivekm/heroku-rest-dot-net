using bilerplate.Application.Contracts.Persistence;
using bilerplate.Infrastructure.EncryptDecrypt;
using bilerplate.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bilerplate.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = string.Empty;
            var envvar = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (envvar == "Development")
            {
                defaultConnectionString = configuration.GetConnectionString("ConnectionStrings");
            }
            else
            {
                // Use connection string provided at runtime by Heroku.
                var connectionUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                connectionUrl = connectionUrl.Replace("postgres://", string.Empty);
                var userPassSide = connectionUrl.Split("@")[0];
                var hostSide = connectionUrl.Split("@")[1];

                var user = userPassSide.Split(":")[0];
                var password = userPassSide.Split(":")[1];
                var host = hostSide.Split("/")[0];
                var database = hostSide.Split("/")[1].Split("?")[0];

                defaultConnectionString = $"Host={host};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
            }
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ApplicationConnectionString")));
            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
            catch
            {
            }
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
