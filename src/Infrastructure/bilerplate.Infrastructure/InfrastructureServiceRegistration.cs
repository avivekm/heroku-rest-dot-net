using bilerplate.Application.Contracts.Infrastructure;
using bilerplate.Application.Models.Cache;
using bilerplate.Application.Models.Mail;
using bilerplate.Infrastructure.Cache;
using bilerplate.Infrastructure.FileExport;
using bilerplate.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Extensions.DependencyInjection;

namespace bilerplate.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();
            services.Configure<CacheConfiguration>(configuration.GetSection("CacheConfiguration"));
            services.AddMemoryCache();
            services.AddTransient<ICacheService, MemoryCacheService>();
            services.AddSendGrid(options => { options.ApiKey = configuration.GetValue<string>("EmailSettings:ApiKey"); });
            return services;
        }
    }
}
