using Moq;
using Xunit;
using FluentAssertions;
using Campaigns.Logic.Campaign;
using Campaigns.Logic.Order;
using Campaigns.Logic.Product;
using Campaigns.Logic.SharedKernel;
using Campaigns.Logic.SystemInfo;
using Campaigns.Logic.Utils;

namespace Campaigns.Tests
{
    [Collection("Sequential")]
    public class ProductSpecs
    {
        Mock<INotifierMediatorService> _mediatorServiceMock;

        private readonly ICampaign _campaign;
        private readonly IOrder _order;
        private readonly IProduct _product;
        private readonly ISystemInfo _systemInfo;

        public ProductSpecs()
        {
            _mediatorServiceMock = new Mock<INotifierMediatorService>();
           
            _campaign = new Campaign(_mediatorServiceMock.Object);
            _product = new Product(_mediatorServiceMock.Object, _campaign);
            _order = new Order(_mediatorServiceMock.Object,_campaign, _product);
            _systemInfo = new SystemInfo(_mediatorServiceMock.Object,_campaign, _product,_order);
        }

        [Fact]
        public void Create_and_get_product()
        {
            _product.Create(new ProductItem(new ProductCode("P2"), 5, 10));

            var productDetail = _product.GetProductByProductCode(new ProductCode("P2"));

            productDetail.ProductCode.Value.Should().Be("P2");
            productDetail.Quantity.Should().Be(5);
            productDetail.Price.Should().Be(10);
        }

        [Fact]
        public void Check_product_discountPrice_when_campaign_created()
        {
            _systemInfo.ResetSystemTime();

            _product.Create(new ProductItem(new ProductCode("P2"), 3, 4));
            _campaign.Create(new CampaignItem("C2", new ProductCode("P2"), 5, 5, 100));
            _systemInfo.IncreaseSystemTime(1);

            var discountedProduct = _product.GetProductByProductCode(new ProductCode("P2"));
            discountedProduct.DiscountedPrice.Should().Be(3.8m);

            _systemInfo.IncreaseSystemTime(6);
            
            var product = _product.GetProductByProductCode(new ProductCode("P2"));
            product.DiscountedPrice.Should().Be(null);
        }
    }
}
