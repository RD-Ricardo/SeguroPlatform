using Microsoft.Extensions.DependencyInjection;
using Proposal.Application.Ports.Inbound.UseCases;
using Proposal.Application.UseCases;

namespace Proposal.Application
{
    public static class ApplicationModule
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ICreateProposalUseCase, CreateProposalUseCase>();
            services.AddScoped<IGetAllProposalsUseCase, GetAllProposalsUseCase>();
            services.AddScoped<IUpdateProposalStatusUseCase, UpdateProposalStatusUseCase>();
        }
    }
}
