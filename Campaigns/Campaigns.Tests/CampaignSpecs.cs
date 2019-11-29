using Campaigns.Logic.Campaign;
using Campaigns.Logic.Order;
using Campaigns.Logic.Product;
using Campaigns.Logic.SharedKernel;
using Campaigns.Logic.SystemInfo;
using Campaigns.Logic.Utils;
using FluentAssertions;
using Moq;
using Xunit;

namespace Campaigns.Tests
{
    [Collection("Sequential")]
    public class CampaignSpecs
    {
        Mock<INotifierMediatorService> _mediatorServiceMock;

        private readonly ICampaign _campaign;
        private readonly IOrder _order;
        private readonly IProduct _product;
        private readonly ISystemInfo _systemInfo;

        public CampaignSpecs()
        {
            _mediatorServiceMock = new Mock<INotifierMediatorService>();

            _campaign = new Campaign(_mediatorServiceMock.Object);
            _product = new Product(_mediatorServiceMock.Object, _campaign);
            _order = new Order(_mediatorServiceMock.Object,_campaign, _product);
            _systemInfo = new SystemInfo(_mediatorServiceMock.Object,_campaign, _product,_order);
        }

        [Fact]
        public void Create_campaign()
        {
            _campaign.Create(new CampaignItem("C1", new ProductCode("P1"), 5, 5, 100));

            var campaignDetail = _campaign.GetCampaignByName("C1");

            campaignDetail.Name.Should().Be("C1");
            campaignDetail.ProductCode.Value.Should().Be("P1");
            campaignDetail.Duration.Should().Be(5);
            campaignDetail.PriceManipulationLimit.Should().Be(5);
            campaignDetail.PriceManipulationLimit.Should().Be(5);
            campaignDetail.TargetSalesCount.Should().Be(100);
            campaignDetail.Status.Should().Be(CampaignStatus.Active);

        }

        [Fact]
        public void Create_campaign_check_status_when_time_is_up()
        {
            _campaign.Create(new CampaignItem("C1", new ProductCode("P1"), 5, 5, 100));
            _systemInfo.IncreaseSystemTime(6);

            var campaignDetail = _campaign.GetCampaignByName("C1");

            campaignDetail.Status.Should().Be(CampaignStatus.Passive);
        }
    }
}
