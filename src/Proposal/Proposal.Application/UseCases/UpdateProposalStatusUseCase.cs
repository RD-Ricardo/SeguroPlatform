using ErrorOr;
using Proposal.Application.Ports.Inbound.Dtos;
using Proposal.Application.Ports.Inbound.UseCases;
using Proposal.Application.Ports.Outbound.Database;
using Proposal.Application.Ports.Outbound.Messaging;

namespace Proposal.Application.UseCases
{
    public class UpdateProposalStatusUseCase : IUpdateProposalStatusUseCase
    {
        private readonly IProposalRepository _proposalRepository;

        private readonly IMessageSender _messageSender;

        public UpdateProposalStatusUseCase(IProposalRepository proposalRepository, IMessageSender messageSender)
        {
            _proposalRepository = proposalRepository;
            _messageSender = messageSender;
        }

        public async Task<ErrorOr<bool>> ExecuteAsync(Guid proposalId, ProposalUpdateeDto inbound)
        {
            var proposal = await _proposalRepository.GetByIdAsync(proposalId);

            if (proposal is null)
            {
                return Error.NotFound("Proposal not found.");
            }

            if (inbound.Status == Domain.Enums.ProposalStatus.Approved && proposal.Status != Domain.Enums.ProposalStatus.Pending)
                return Error.Validation("Proposal can only be approved if it is pending.");

            ChangeStatus(inbound, proposal);

            _proposalRepository.Update(proposal);

            await _proposalRepository.SaveAsync();

            if (proposal.Status == Domain.Enums.ProposalStatus.Approved)
            {
                await _messageSender.SendMessageHireProposalAsync(new Domain.Events.ProposalHireEvent(proposal.Id,
                   proposal.ClientName,
                   proposal.ProductName,
                   proposal.Amount,
                   DateTime.UtcNow));
            }

            return true;
        }

        private static void ChangeStatus(ProposalUpdateeDto inbound, Domain.Entities.Proposal proposal)
        {
            if (inbound.Status == Domain.Enums.ProposalStatus.Rejeitada)
                proposal.Reject();

            if (inbound.Status == Domain.Enums.ProposalStatus.Approved)
                proposal.Approve();
        }
    }
}
