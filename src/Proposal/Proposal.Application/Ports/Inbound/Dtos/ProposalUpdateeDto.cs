using Proposal.Domain.Enums;

namespace Proposal.Application.Ports.Inbound.Dtos
{
    public class ProposalUpdateeDto
    {
        public ProposalStatus Status { get; set; }
    }
}
