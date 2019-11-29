using MediatR;
using Campaigns.Logic.Product;
using Campaigns.Logic.SharedKernel;

namespace Campaigns.App.Product.Query
{
    public class GetProductCommandQuery : IRequest<ProductItem>
    {
        public ProductCode ProductCode { get; }

        public GetProductCommandQuery(string productCode)
        {
            this.ProductCode = new ProductCode(productCode);
        }
    }
}
