using Campaigns.Logic.SharedKernel;
using System.Collections.Generic;

namespace Campaigns.Logic.Product
{
    public interface IProduct
    {
        void Create(ProductItem product);

        ProductItem GetProductByProductCode(ProductCode productCode);
        List<ProductItem> GetList();
    }
}
