using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Proposal.Infra.Database
{
    public class ProposalDbContextFactory
    {
        public ProposalDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{env}.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ProposalDbContext>()
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            return new ProposalDbContext(builder.Options);
        }
    }
}
