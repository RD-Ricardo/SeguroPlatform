using ErrorOr;
using Proposal.Application.Ports.Inbound.Dtos;
using Proposal.Application.Ports.Inbound.UseCases;
using Proposal.Application.Ports.Outbound.Database;

namespace Proposal.Application.UseCases
{
    public class GetAllProposalsUseCase : IGetAllProposalsUseCase
    {
        private readonly IProposalRepository _proposalRepository;
        public GetAllProposalsUseCase(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public async Task<ErrorOr<List<ProposalDto>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var proposals = await _proposalRepository.GetAllsAsync();

            if (proposals is null || !proposals.Any())
            {
                return Error.NotFound("No proposals found.");
            }

            var proposalDtos = proposals.Select(p => new ProposalDto(
                p.Id,
                p.ClientName,
                p.ClientDocument,
                p.ProductName,
                p.Amount,
                p.Status,
                p.CreatedAt,
                p.UpdatedAt
            )).ToList();

            return proposalDtos;
        }
    }
}
