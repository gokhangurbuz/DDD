using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.Product;
using Campaigns.App.Product.Query;

namespace Campaigns.App.Product.Command
{
    public class GetProductCommandQueryHandler : IRequestHandler<GetProductCommandQuery, ProductItem>
    {
        private readonly IProduct _product;

        public GetProductCommandQueryHandler(IProduct product)
        {
            _product = product;
        }

        public async Task<ProductItem> Handle(GetProductCommandQuery request, CancellationToken cancellationToken)
        {
            return _product.GetProductByProductCode(request.ProductCode);
        }
    }
}
