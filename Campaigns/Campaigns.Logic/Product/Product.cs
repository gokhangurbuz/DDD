using Campaigns.Logic.Campaign;
using Campaigns.Logic.Common;
using Campaigns.Logic.SharedKernel;
using Campaigns.Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Campaigns.Logic.Product
{
    public class Product : AggregateRoot, IProduct
    {
        protected virtual IList<ProductItem> _products { get; }
        private readonly INotifierMediatorService _notifierMediatorService;
        private ICampaign _campaign { get; set; }

        public Product(INotifierMediatorService notifierMediatorService, ICampaign campaign)
        {
            _products = new List<ProductItem>();
            _notifierMediatorService = notifierMediatorService;
            _campaign = campaign;
        }

        public void Create(ProductItem product)
        {
            _products.Add(product);
            
            _notifierMediatorService.Notify("Product created; " + product.ToString());
        }

        public ProductItem GetProductByProductCode(ProductCode productCode)
        {
            var product = _products.Single(q => q.ProductCode == productCode);
         
            _notifierMediatorService.Notify($"Product {productCode.Value} info; " + product.ToString());

            return product;
        }

        public List<ProductItem> GetList()
        {
            return _products.ToList();
        }
    }
}