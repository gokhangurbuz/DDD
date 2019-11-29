using System;
using System.Linq;
using Campaigns.Logic.Campaign;
using Campaigns.Logic.Common;
using Campaigns.Logic.Order;
using Campaigns.Logic.Product;
using Campaigns.Logic.Utils;

namespace Campaigns.Logic.SystemInfo
{
    public class SystemInfo : AggregateRoot, ISystemInfo
    {
        private readonly INotifierMediatorService _notifierMediatorService;
        private ICampaign _campaign;
        private IProduct _product;
        private IOrder _order;

        public SystemInfo(INotifierMediatorService notifierMediatorService, ICampaign campaign, IProduct product, IOrder order)
        {
            _notifierMediatorService = notifierMediatorService;
            _campaign = campaign;
            _product = product;
            _order = order;
        }

        public DateTime GetSystemTime()
        {
            _notifierMediatorService.Notify("Current time; " + this.GetTime().ToString("HH:mm"));

            return this.GetTime();
        }

        public void IncreaseSystemTime(int time)
        {
            this.IncreaseTime(time);

            var campaingList = _campaign.GetList();
            var productList = _product.GetList();

            foreach (var campaign in campaingList)
            {
                var orderList = _order.GetOrderListByProductCode(campaign.ProductCode);
                int orderCount = orderList.Sum(q => q.Quantity);

                var product = productList.SingleOrDefault(q => q.ProductCode == campaign.ProductCode);

                if (GetTime().Hour >= campaign.Duration || orderCount >= campaign.TargetSalesCount)
                {
                    campaign.SetStatusAsPassive();
                    product?.RemoveDiscountedPrice();
                }
                else
                {
                    product?.SetDiscountedPrice(product.Price - (product.Price * campaign.PriceManipulationLimit * GetTime().Hour / 100));
                }
            }

            _notifierMediatorService.Notify("Time is; " + this.GetTime().ToString("HH:mm"));
        }

        public void ResetSystemTime()
        {
            this.ResetTime();
        }
    }
}
