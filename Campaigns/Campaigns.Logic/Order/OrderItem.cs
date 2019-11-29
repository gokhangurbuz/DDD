using System;
using Campaigns.Logic.Common;
using Campaigns.Logic.SharedKernel;

namespace Campaigns.Logic.Order
{
    public class OrderItem : ValueObject<OrderItem>
    {
        public ProductCode ProductCode { get; }

        public int Quantity { get; }

        public decimal Price { get; private set; }

        private OrderItem()
        {
        }

        public OrderItem(ProductCode productCode, int quantity)
        {
            if (quantity < 0)
                throw new InvalidOperationException();

            ProductCode = productCode;
            Quantity = quantity;
        }
        public OrderItem SetPrice(decimal price)
        {
            Price = price;

            return this;
        }

        protected override bool EqualsCore(OrderItem other)
        {
            return ProductCode == other.ProductCode
                 && Quantity == other.Quantity;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = ProductCode.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();

                return hashCode;
            }
        }
        public override string ToString()
        {
            return String.Format("product {0}, quantity {1}", ProductCode.Value, Quantity);
        }
    }
}
