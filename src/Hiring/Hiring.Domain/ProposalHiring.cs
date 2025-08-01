namespace Hiring.Domain
{
    public class ProposalHiring
    {
        public Guid Id { get; set; }
        public Guid ProposalId { get; set; }
        public string? ClientName { get; set; }
        public string? ProductName { get; set; }
        public decimal Amount { get; set; }
        public DateTime HireDate { get; set; }
    }
}
