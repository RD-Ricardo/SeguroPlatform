using Microsoft.EntityFrameworkCore;
using Proposal.Application.Ports.Outbound.Database;

namespace Proposal.Infra.Database.Repositories
{
    public class ProposalRepository : IProposalRepository
    {
        private readonly ProposalDbContext _context;
        public ProposalRepository(ProposalDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.Entities.Proposal proposal)
        {
            await _context.Proposals.AddAsync(proposal);
            await _context.SaveChangesAsync();
        }

        public Task<List<Domain.Entities.Proposal>> GetAllsAsync()
        {
            return _context.Proposals
                .ToListAsync();
        }

        public Task<Domain.Entities.Proposal?> GetByIdAsync(Guid id)
        {
            return _context.Proposals
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Domain.Entities.Proposal proposal)
        {
            _context.Proposals.Update(proposal);
        }
    }
}
