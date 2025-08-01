using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Proposal.Infra.Database.Configurations
{
    public class ProposalConfiguration : IEntityTypeConfiguration<Domain.Entities.Proposal>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Proposal> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();
            
            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(200);
            
            builder.Property(p => p.ClientName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.ClientDocument)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasPrecision(16, 2);
        }
    }
}
