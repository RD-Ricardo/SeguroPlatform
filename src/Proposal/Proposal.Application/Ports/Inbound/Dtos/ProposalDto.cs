using Proposal.Domain.Enums;

namespace Proposal.Application.Ports.Inbound.Dtos
{
    public record ProposalDto(Guid Id, 
        string ClientName, 
        string ClientDocument, 
        string ProductName, 
        decimal Amount, 
        ProposalStatus Status, 
        DateTime CreatedAt, 
        DateTime? UpdatedAt);
}
