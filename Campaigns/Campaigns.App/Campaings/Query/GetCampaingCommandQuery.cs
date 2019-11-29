using MediatR;
using Campaigns.Logic.Campaign;

namespace Campaigns.App.Campaings.Command
{
    public class GetCampaingCommandQuery : IRequest<CampaignItem>
    {
        public string Name { get; }

        public GetCampaingCommandQuery(string name)
        {
            this.Name = name;
        }
    }
}
