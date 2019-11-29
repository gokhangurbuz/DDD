using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.Campaign;
using Campaigns.App.Campaings.Command;

namespace Campaigns.App.Product.Command
{
    public class GetCampaingCommandQueryHandler : IRequestHandler<GetCampaingCommandQuery, CampaignItem>
    {
        private readonly ICampaign _campaing;

        public GetCampaingCommandQueryHandler(ICampaign campaign)
        {
            _campaing = campaign;
        }

        public async Task<CampaignItem> Handle(GetCampaingCommandQuery request, CancellationToken cancellationToken)
        {
            return _campaing.GetCampaignByName(request.Name);
        }
    }
}
