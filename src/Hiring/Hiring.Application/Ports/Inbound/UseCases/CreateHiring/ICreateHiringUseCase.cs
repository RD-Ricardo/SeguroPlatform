namespace Hiring.Application.Ports.Inbound.UseCases.CreateHiring
{
    public interface ICreateHiringUseCase
    {
        Task ExecuteAsync(ProposalHireCreateDto proposalHireCreateDto);
    }
}
