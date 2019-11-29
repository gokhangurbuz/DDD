using MediatR;

namespace Campaigns.App.Order.Command
{
    public class CreateOrderCommand : IRequest
    {
        public string ProductCode { get; private set; }
        public int Quantity { get; private set; }

        public CreateOrderCommand(string productCode, int quantity)
        {
            ProductCode = productCode;
            Quantity = quantity;
        }
    }
}
