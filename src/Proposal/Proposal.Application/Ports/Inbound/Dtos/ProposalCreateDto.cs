namespace Proposal.Application.Ports.Inbound.Dtos
{
    public class ProposalCreateDto
    {
        public string ClientName { get; set; } = string.Empty;
        public string ClientDocument { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Amount { get; set; } 
    }
}
