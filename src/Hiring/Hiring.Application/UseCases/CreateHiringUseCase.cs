using Hiring.Application.Ports.Inbound.UseCases.CreateHiring;
using Hiring.Application.Ports.Outbound.Database;

namespace Hiring.Application.UseCases
{
    public class CreateHiringUseCase : ICreateHiringUseCase
    {
        private readonly IHiringRepository _hiringRepository;
        public CreateHiringUseCase(IHiringRepository hiringRepository)
        {
            _hiringRepository = hiringRepository;
        }

        public async Task ExecuteAsync(ProposalHireCreateDto proposalHireCreateDto)
        {
            var proposalHiring = new Domain.ProposalHiring
            {
                Id = Guid.NewGuid(),
                ProposalId = proposalHireCreateDto.ProposalId,
                Amount = proposalHireCreateDto.Amount,
                ClientName = proposalHireCreateDto.ClientName,
                HireDate = proposalHireCreateDto.HireDate,
                ProductName = proposalHireCreateDto.ProductName,
            };

            await _hiringRepository.CreateAsync(proposalHiring);
        }
    }
}
