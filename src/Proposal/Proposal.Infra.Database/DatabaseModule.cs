using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Proposal.Application.Ports.Outbound.Database;
using Proposal.Infra.Database.Repositories;

namespace Proposal.Infra.Database
{
    public static class DatabaseModule
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProposalDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IProposalRepository, ProposalRepository>();
        }
    }
}
