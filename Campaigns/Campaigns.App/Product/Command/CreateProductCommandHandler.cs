using System.Threading;
using System.Threading.Tasks;
using Campaigns.Logic.Product;
using Campaigns.Logic.SharedKernel;
using MediatR;

namespace Campaigns.App.Product.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProduct _product;

        public CreateProductCommandHandler(IProduct product)
        {
            _product = product;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
           _product.Create(new ProductItem(new ProductCode(request.ProductCode), request.Quantity, request.Price));

            return Unit.Value;
        }
    }
}
