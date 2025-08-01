namespace Hiring.Application.Ports.Inbound.UseCases.CreateHiring
{
    public record ProposalHireCreateDto(
       Guid ProposalId,
       string ClientName,
       string ProductName,
       decimal Amount,
       DateTime HireDate
   );
}
