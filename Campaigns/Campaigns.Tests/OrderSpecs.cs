using Campaigns.Logic.Campaign;
using Campaigns.Logic.Order;
using Campaigns.Logic.Product;
using Campaigns.Logic.SharedKernel;
using Campaigns.Logic.SystemInfo;
using Campaigns.Logic.Utils;
using FluentAssertions;
using Moq;
using System.Linq;
using Xunit;

namespace Campaigns.Tests
{
    [Collection("Sequential")]
    public class OrderSpecs
    {
        Mock<INotifierMediatorService> _mediatorServiceMock;

        private readonly ICampaign _campaign;
        private readonly IOrder _order;
        private readonly IProduct _product;
        private readonly ISystemInfo _systemInfo;

        public OrderSpecs()
        {
            _mediatorServiceMock = new Mock<INotifierMediatorService>();

            _campaign = new Campaign(_mediatorServiceMock.Object);
            _product = new Product(_mediatorServiceMock.Object, _campaign);
            _order = new Order(_mediatorServiceMock.Object,_campaign, _product);
            _systemInfo = new SystemInfo(_mediatorServiceMock.Object,_campaign, _product,_order);
        }

        [Fact]
        public void Create_and_get_order()
        {
            _product.Create(new ProductItem(new ProductCode("P1"), 3, 4));
            _order.Create(new OrderItem(new ProductCode("P1"),1));

            var orderDetail = _order.GetOrderListByProductCode(new ProductCode("P1"));

            orderDetail.First().ProductCode.Value.Should().Be("P1");
            orderDetail.First().Price.Should().Be(4);
            orderDetail.First().Quantity.Should().Be(1);
        }
    }
}
