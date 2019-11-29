using MediatR;

namespace Campaigns.App.Product.Command
{
    public class CreateProductCommand : IRequest
    {
        public string ProductCode { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public CreateProductCommand(string productCode,
            int quantity,
            int price)
        {
            ProductCode = productCode;
            Quantity = quantity;
            Price = price;
        }
    }
}
