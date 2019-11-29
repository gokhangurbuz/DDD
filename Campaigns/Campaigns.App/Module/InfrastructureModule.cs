using Autofac;
using Campaigns.Logic.Utils;
using Campaigns.Logic.Order;
using Campaigns.Logic.Product;
using Campaigns.Logic.Campaign;
using Campaigns.App.Data;

namespace Campaigns.App.Module
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Logic.SystemInfo.SystemInfo>()
             .As<Logic.SystemInfo.ISystemInfo>()
             .InstancePerLifetimeScope();

            builder.RegisterType<Campaign>()
             .As<ICampaign>()
             .InstancePerLifetimeScope();

            builder.RegisterType<Logic.Order.Order>()
             .As<IOrder>()
             .InstancePerLifetimeScope();

            builder.RegisterType<Logic.Product.Product>()
             .As<IProduct>()
             .InstancePerLifetimeScope();

            builder.RegisterType<NotifierMediatorService>()
             .As<INotifierMediatorService>()
             .InstancePerLifetimeScope();

            builder.RegisterType<DataFromFile>()
            .As<IData>()
            .InstancePerLifetimeScope();
        }
    }
}
