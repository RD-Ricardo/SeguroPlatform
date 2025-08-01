using Microsoft.EntityFrameworkCore;

namespace Proposal.Infra.Database
{
    public class ProposalDbContext : DbContext
    {
        public ProposalDbContext(DbContextOptions<ProposalDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProposalDbContext).Assembly);
        }

        public DbSet<Domain.Entities.Proposal> Proposals { get; set; }
    }
}
