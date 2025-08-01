using ErrorOr;
using Proposal.Application.Ports.Inbound.Dtos;

namespace Proposal.Application.Ports.Inbound.UseCases
{

    public interface ICreateProposalUseCase
    {
        Task<ErrorOr<bool>> ExecuteAsync(ProposalCreateDto inbound);
    }
}
