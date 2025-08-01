namespace Hiring.Application.Ports.Inbound.UseCases.GetAllHirings
{
    public interface IGetAllHiringsUseCase
    {
        Task<List<ProposalHireDto>> ExecuteAsync();
    }
}
