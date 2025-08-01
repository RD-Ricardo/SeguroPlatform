using ErrorOr;
using Proposal.Application.Ports.Inbound.Dtos;

namespace Proposal.Application.Ports.Inbound.UseCases
{

    public interface IUpdateProposalStatusUseCase
    {
        Task<ErrorOr<bool>> ExecuteAsync(Guid proposalId, ProposalUpdateeDto inbound);
    }
}
