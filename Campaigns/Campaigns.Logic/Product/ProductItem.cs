using System;
using Campaigns.Logic.Common;
using Campaigns.Logic.SharedKernel;

namespace Campaigns.Logic.Product
{
    public class ProductItem : ValueObject<ProductItem>
    {
        public ProductCode ProductCode { get; private set; }

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }
        public decimal? DiscountedPrice { get; private set; }

        private ProductItem()
        {
        }

        public ProductItem(ProductCode productCode, int quantity, decimal price)
        {
            if (quantity < 0)
                throw new InvalidOperationException();
            if (price < 0)
                throw new InvalidOperationException();

            ProductCode = productCode;
            Quantity = quantity;
            Price = price;
        }

        public virtual void SetDiscountedPrice(decimal discountedPrice)
        {
            if (!(discountedPrice <= 0))
                DiscountedPrice = discountedPrice;
        }

        public virtual void RemoveDiscountedPrice()
        {
            DiscountedPrice = null;
        }

        public virtual void DecreaseQuantity(int quantity)
        {
            Quantity -= quantity;
        }

        protected override bool EqualsCore(ProductItem other)
        {
            return ProductCode == other.ProductCode
                 && Quantity == other.Quantity
                 && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = ProductCode.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity.GetHashCode();
                hashCode = (hashCode * 397) ^ Price.GetHashCode();

                return hashCode;
            }
        }
        public override string ToString()
        {
            return String.Format("code {0}, quantity {1}, price {2}", ProductCode.Value, Quantity, DiscountedPrice ?? Price);
        }
    }
}
