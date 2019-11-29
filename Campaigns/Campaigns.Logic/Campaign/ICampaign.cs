using Campaigns.Logic.SharedKernel;
using System.Collections.Generic;

namespace Campaigns.Logic.Campaign
{
    public interface ICampaign
    {
        void Create(CampaignItem campaign);

        CampaignItem GetCampaignByName(string name);
        CampaignItem GetCampaignByProductCode(ProductCode productCode);
        List<CampaignItem> GetList();
    }
}
