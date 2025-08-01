using Microsoft.AspNetCore.Mvc;
using Proposal.Application.Ports.Inbound.Dtos;
using Proposal.Application.Ports.Inbound.UseCases;

namespace Proposal.Api.Controllers
{
    [ApiController]
    [Route("api/proposas")]
    public class ProposalController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProposal([FromBody] ProposalCreateDto proposalCreateDto, [FromServices] ICreateProposalUseCase createProposalUseCase)
        {
            var result = await createProposalUseCase.ExecuteAsync(proposalCreateDto);

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

        [HttpPut("{id:guid}/status")]
        public async Task<IActionResult> UpdateProposalStatus(
            [FromRoute] Guid id,
            [FromBody] ProposalUpdateeDto ProposalUpdateeDto,
            [FromServices] IUpdateProposalStatusUseCase updateProposalStatusUseCase)
        {
            var result = await updateProposalStatusUseCase.ExecuteAsync(id, ProposalUpdateeDto);

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(error)
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProposal(
            [FromServices]  IGetAllProposalsUseCase getAllProposalsUseCase, 
            CancellationToken cancellationToken)
        {
            var result = await getAllProposalsUseCase.ExecuteAsync(cancellationToken);

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(error)
            );
        }
    }
}
