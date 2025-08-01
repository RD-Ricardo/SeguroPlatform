using Hiring.Database.Repositories;
using Microsoft.Extensions.Configuration;
using SeguroPlataform.Common.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hiring.Application.Ports.Outbound.Database;

namespace Hiring.Database
{
    public static class DatabaseModule
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDb(configuration); 
            services.AddScoped<IHiringRepository, HiringRepository>();
        }
    }
}
