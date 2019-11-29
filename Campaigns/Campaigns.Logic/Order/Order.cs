using Campaigns.Logic.Campaign;
using Campaigns.Logic.Common;
using Campaigns.Logic.Product;
using Campaigns.Logic.SharedKernel;
using Campaigns.Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Campaigns.Logic.Order
{
    public class Order : AggregateRoot, IOrder
    {
        protected virtual IList<OrderItem> _orders { get; }
        private readonly INotifierMediatorService _notifierMediatorService;
        private ICampaign _campaign;
        private IProduct _product;

        public Order(INotifierMediatorService notifierMediatorService, ICampaign campaign, IProduct product)
        {
            _orders = new List<OrderItem>();
            _notifierMediatorService = notifierMediatorService;
            _campaign = campaign;
            _product = product;
        }

        public void Create(OrderItem order)
        {
            var product = _product.GetList().Single(q => q.ProductCode == order.ProductCode);
            
            if (product.Quantity > 0)
            {
                _orders.Add(order.SetPrice(product.DiscountedPrice ?? product.Price));

                product.DecreaseQuantity(order.Quantity);

                var campaign = _campaign.GetCampaignByProductCode(order.ProductCode);
                if (campaign != null)
                {
                    campaign.IncreaseSalesCount(order.Quantity);

                    var orderList = _orders.Where(q => q.ProductCode == order.ProductCode);
                    if (orderList.Any())
                    {
                        var averagePrice = orderList.Sum(q => q.Quantity * q.Price)/ orderList.Sum(q => q.Quantity);
                        campaign.SetAveragePrice(averagePrice);
                    }
                }

                _notifierMediatorService.Notify("Order created; " + order.ToString());
            }
        }

        public List<OrderItem> GetOrderListByProductCode(ProductCode productCode)
        {
            return _orders.Where(q => q.ProductCode == productCode).ToList();
        }
    }
}
