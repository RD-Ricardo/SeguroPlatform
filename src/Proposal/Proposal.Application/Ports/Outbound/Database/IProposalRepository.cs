namespace Proposal.Application.Ports.Outbound.Database
{
    public interface IProposalRepository
    {
        Task AddAsync(Domain.Entities.Proposal proposal);
        Task<Domain.Entities.Proposal?> GetByIdAsync(Guid id);
        Task<List<Domain.Entities.Proposal>> GetAllsAsync();
        void Update(Domain.Entities.Proposal proposal);

        Task SaveAsync();
    }
}
