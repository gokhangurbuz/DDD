using Campaigns.Logic.SharedKernel;
using System.Collections.Generic;

namespace Campaigns.Logic.Order
{
    public interface IOrder
    {
        void Create(OrderItem product);
        List<OrderItem> GetOrderListByProductCode(ProductCode productCode);
    }
}
