using MediatR;
using System.Threading;
using Campaigns.Logic.Order;
using System.Threading.Tasks;
using Campaigns.Logic.SharedKernel;

namespace Campaigns.App.Order.Command
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrder _order;

        public CreateOrderCommandHandler(IOrder order)
        {
            _order = order;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            _order.Create(new OrderItem(new ProductCode(request.ProductCode), request.Quantity));

            return Unit.Value;
        }
    }
}
