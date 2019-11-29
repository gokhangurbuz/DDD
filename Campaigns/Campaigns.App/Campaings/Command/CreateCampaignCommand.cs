using MediatR;

namespace Campaigns.App.Campaings.Command
{
    public class CreateCampaignCommand : IRequest
    {
        public string Name { get; private set; }
        public string ProductCode { get; private set; }
        public int Duration { get; private set; }
        public int PriceManipulationLimit { get; private set; }
        public int TargetSalesCount { get; private set; }

        public CreateCampaignCommand(string name,
            string productCode,
            int duration,
            int priceManipulationLimit,
            int targetSalesCount)
        {
            Name = name;
            ProductCode = productCode;
            Duration = duration;
            PriceManipulationLimit = priceManipulationLimit;
            TargetSalesCount = targetSalesCount;
        }
    }
}
