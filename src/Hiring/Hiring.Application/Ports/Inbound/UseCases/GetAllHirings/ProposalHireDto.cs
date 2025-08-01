using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hiring.Application.Ports.Inbound.UseCases.GetAllHirings
{
    public class ProposalHireDto
    {
        public Guid Id { get; set; }
        public Guid ProposalId { get; set; }
        public string? ClientName { get; set; }
        public string? ProductName { get; set; }
        public decimal Amount { get; set; }
        public DateTime HireDate { get; set; }
    }
}
