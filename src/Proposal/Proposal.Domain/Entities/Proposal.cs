using Proposal.Domain.Enums;
using Proposal.Domain.Exceptions;

namespace Proposal.Domain.Entities
{
    public class Proposal 
    {
        public Guid Id { get; private set; }
        public string ClientName { get; private set; }
        public string ClientDocument { get; private set; }
        public string ProductName { get; private set; }
        public decimal Amount { get; private set; }
        public ProposalStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Proposal(string clientName, string clientDocument, string productName, decimal amount)
        {
            Id = Guid.NewGuid();
            ClientName = clientName;
            ClientDocument = clientDocument;
            ProductName = productName;
            Amount = amount;
            CreatedAt = DateTime.UtcNow;
            Status = ProposalStatus.Pending;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(ClientName))
                throw new DomainException("Client name cannot be empty.");

            if (string.IsNullOrWhiteSpace(ClientDocument))
                throw new DomainException("Client document cannot be empty.");
            
            if (string.IsNullOrWhiteSpace(ProductName))
                throw new DomainException("Product name cannot be empty.");
            
            if (Amount <= 0)
                throw new DomainException("Amount must be greater than zero.");
        }

        public void Approve()
        {
            if (Status != ProposalStatus.Pending)
                throw new DomainException("Only pending proposals can be approved.");

            Status = ProposalStatus.Approved;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Reject()
        {
            if (Status != ProposalStatus.Pending)
                throw new DomainException("Only pending proposals can be rejected.");

            Status = ProposalStatus.Rejeitada;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
