using Hiring.Domain;

namespace Hiring.Application.Ports.Outbound.Database
{
    public interface IHiringRepository
    {
        Task CreateAsync(ProposalHiring hiring);
        Task<List<ProposalHiring>> GetAllAsync();
    }
}
