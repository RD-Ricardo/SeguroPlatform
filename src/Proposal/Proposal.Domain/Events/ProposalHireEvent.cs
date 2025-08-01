namespace Proposal.Domain.Events
{
    public record ProposalHireEvent(
        Guid ProposalId,
        string ClientName,
        string ProductName,
        decimal Amount,
        DateTime HireDate
    );
}
