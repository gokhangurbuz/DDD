using System;
using Campaigns.Logic.Common;

namespace Campaigns.Logic.SharedKernel
{
    public sealed class ProductCode : ValueObject<ProductCode>
    {
        public string Value { get; private set; }

        protected ProductCode()
        {
        }

        public ProductCode(string value)
        {
            if (value.Length == 0 || value.Length > 40)
                throw new InvalidOperationException();

            Value = value;
        }

        protected override bool EqualsCore(ProductCode other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                return Value.GetHashCode();
            }
        }
    }
}
