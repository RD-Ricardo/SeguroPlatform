using ErrorOr;
using Proposal.Application.Ports.Inbound.Dtos;
using Proposal.Application.Ports.Inbound.UseCases;
using Proposal.Application.Ports.Outbound.Database;

namespace Proposal.Application.UseCases
{
    public class CreateProposalUseCase : ICreateProposalUseCase
    {
        private readonly IProposalRepository _proposalRepository;
        public CreateProposalUseCase(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        public async Task<ErrorOr<bool>> ExecuteAsync(ProposalCreateDto inbound)
        {
            try
            {
                var proposal = new Domain.Entities.Proposal(
                    inbound.ClientName, 
                    inbound.ClientDocument, 
                    inbound.ProductName, 
                    inbound.Amount);

                await _proposalRepository.AddAsync(proposal);

                await _proposalRepository.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                return Error.Failure("An error occurred while creating the proposal: " + ex.Message);
            }
        }
    }
}
