using ErrorOr;
using Proposal.Application.Ports.Inbound.Dtos;

namespace Proposal.Application.Ports.Inbound.UseCases
{
    public interface IGetAllProposalsUseCase
    {
        Task<ErrorOr<List<ProposalDto>>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
