using System.Linq;
using Campaigns.Logic.Common;
using Campaigns.Logic.SharedKernel;
using Campaigns.Logic.Utils;
using System.Collections.Generic;
using Campaigns.Logic.Product;

namespace Campaigns.Logic.Campaign
{
    public class Campaign : AggregateRoot, ICampaign
    {
        protected virtual IList<CampaignItem> _campaigns { get; }
        private readonly INotifierMediatorService _notifierMediatorService;

        public Campaign(INotifierMediatorService notifierMediatorService)
        {
            _campaigns = new List<CampaignItem>();
            _notifierMediatorService = notifierMediatorService;
        }

        public void Create(CampaignItem campaign)
        {
            //add validation for campaign name unique

            _campaigns.Add(campaign);

            _notifierMediatorService.Notify("Campaign created; "+ campaign.ToString());

        }
        public CampaignItem GetCampaignByName(string name)
        {
            var campaign = _campaigns.Single(q => q.Name.Equals(name));

            _notifierMediatorService.Notify($"Campaign {name} info; " + campaign.ToString());

            return campaign;
        }

        public CampaignItem GetCampaignByProductCode(ProductCode productCode)
        {
            var campaign = _campaigns.SingleOrDefault(q => q.ProductCode == productCode);

            return campaign;
        }

        public List<CampaignItem> GetList()
        {
            return _campaigns.ToList();
        }
    }
}
