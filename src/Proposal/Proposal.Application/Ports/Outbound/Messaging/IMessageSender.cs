using Proposal.Domain.Events;

namespace Proposal.Application.Ports.Outbound.Messaging
{
    public interface IMessageSender
    {
        Task SendMessageHireProposalAsync(ProposalHireEvent message);
    }
}
