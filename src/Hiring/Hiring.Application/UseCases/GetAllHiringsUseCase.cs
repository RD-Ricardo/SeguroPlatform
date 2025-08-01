using Hiring.Application.Ports.Inbound.UseCases.GetAllHirings;
using Hiring.Application.Ports.Outbound.Database;

namespace Hiring.Application.UseCases
{
    public class GetAllHiringsUseCase : IGetAllHiringsUseCase
    {
        private readonly IHiringRepository _hiringRepository;
        public GetAllHiringsUseCase(IHiringRepository hiringRepository)
        {
            _hiringRepository = hiringRepository;
        }

        public async Task<List<ProposalHireDto>> ExecuteAsync()
        {
            var hirings = await _hiringRepository.GetAllAsync();

            if (hirings == null || !hirings.Any())
            {
                return new List<ProposalHireDto>();
            }

            return hirings.Select(h => new ProposalHireDto
            {
                Id = h.Id,
                ProposalId = h.ProposalId,
                ProductName = h.ProductName,
                HireDate = h.HireDate,
                ClientName = h.ClientName,
                Amount = h.Amount,
            }).ToList();
        }
    }
}
