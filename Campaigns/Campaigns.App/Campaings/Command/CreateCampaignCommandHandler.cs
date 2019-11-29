using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.Campaign;
using MediatR;

namespace Campaigns.App.Campaings.Command
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand>
    {
        private readonly ICampaign _campaign;

        public CreateCampaignCommandHandler(ICampaign campaign)
        {
            _campaign = campaign;
        }

        public async Task<Unit> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
        {
            _campaign.Create(new CampaignItem(request.Name, new Logic.SharedKernel.ProductCode(request.ProductCode), request.Duration,
                request.PriceManipulationLimit, request.TargetSalesCount));

            return Unit.Value;
        }
    }
}
