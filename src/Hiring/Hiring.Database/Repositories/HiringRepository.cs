using Hiring.Application.Ports.Outbound.Database;
using Hiring.Domain;
using MongoDB.Driver;

namespace Hiring.Database.Repositories
{
    public class HiringRepository : IHiringRepository
    {
        private readonly IMongoCollection<ProposalHiring> _proposalHiringCollection;

        public HiringRepository(IMongoDatabase database)
        {
            _proposalHiringCollection = database.GetCollection<ProposalHiring>("proposal-hirings");
        }

        public async Task CreateAsync(ProposalHiring hiring)
        {
            await _proposalHiringCollection.InsertOneAsync(hiring);
        }

        public async Task<List<ProposalHiring>> GetAllAsync()
        {
            var proposalHirings = await _proposalHiringCollection.Find(_ => true).ToListAsync();
            return proposalHirings;
        }
    }
}
