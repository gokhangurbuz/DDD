using System;
using Campaigns.Logic.Common;
using Campaigns.Logic.SharedKernel;

namespace Campaigns.Logic.Campaign
{
    public class CampaignItem : ValueObject<CampaignItem>
    {
        public string Name { get; private set; }
        public ProductCode ProductCode { get; private set; }
        public int Duration { get; private set; }
        public int PriceManipulationLimit { get; private set; }
        public int TargetSalesCount { get; private set; }
        public int TotalSalesCount { get; private set; }
        public int TurnOver { get; private set; }
        public decimal AverageItemPrice { get; private set; }
        public CampaignStatus Status { get; private set; }

        private CampaignItem()
        {
        }

        public CampaignItem(string name,
            ProductCode productCode,
            int duration,
            int priceManipulationLimit,
            int targetSalesCount)
        {
            if (name.Length == 0 || name.Length > 40)
                throw new InvalidOperationException();
            if (duration < 0)
                throw new InvalidOperationException();
            if (priceManipulationLimit < 0)
                throw new InvalidOperationException();
            if (targetSalesCount < 0)
                throw new InvalidOperationException();

            Name = name;
            ProductCode = productCode;
            Duration = duration;
            PriceManipulationLimit = priceManipulationLimit;
            TargetSalesCount = targetSalesCount;
            Status = CampaignStatus.Active;
        }

        public virtual void IncreaseSalesCount(int quantity)
        {
            if (TotalSalesCount == TargetSalesCount)
                Status = CampaignStatus.Passive;
            else
                TotalSalesCount += quantity;
        }

        public virtual void SetAveragePrice(decimal averagePrice)
        {
            AverageItemPrice = averagePrice;
        }

        public virtual void SetStatusAsPassive()
        {
            Status = CampaignStatus.Passive;
        }

        protected override bool EqualsCore(CampaignItem other)
        {
            return Name == other.Name
                 && ProductCode == other.ProductCode
                 && Duration == other.Duration
                 && PriceManipulationLimit == other.PriceManipulationLimit
                 && TargetSalesCount == other.TargetSalesCount;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ ProductCode.GetHashCode();
                hashCode = (hashCode * 397) ^ Duration.GetHashCode();
                hashCode = (hashCode * 397) ^ PriceManipulationLimit.GetHashCode();
                hashCode = (hashCode * 397) ^ TargetSalesCount.GetHashCode();

                return hashCode;
            }
        }

        public override string ToString()
        {
            return $@"name {Name}, product code {ProductCode.Value}, duration {Duration}, limit {PriceManipulationLimit},
                target sales count {TargetSalesCount}, total sales count {TotalSalesCount}, turn over {TurnOver},
                average item price {AverageItemPrice} status {Status.ToString()}";
        }
    }
}
