using System;
using Autofac;
using MediatR;
using Campaigns.App.Data;
using Campaigns.App.Utils;
using Campaigns.App.Module;
using Campaigns.App.Order.Command;
using Campaigns.App.Product.Query;
using Campaigns.App.Product.Command;
using Campaigns.App.Campaings.Command;
using Campaigns.App.SystemInfo.Command;

namespace Campaigns.App
{
    class Program
    {
        static IContainer container { get; set; }
        static void Main(string[] args)
        {
            container = BuildContainer();

            var mediator = container.Resolve<IMediator>();
            var data = container.Resolve<IData>();

            var commandList = data.Load();

            foreach (var commands in commandList)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Secenario; {commands.Name}");

                foreach (var command in commands.CommandList)
                {
                    dynamic objectInstance = null;

                    object[] parameters = command.Split(" ");

                    string methodName = parameters[0].ToString();

                    parameters = ParameterUtil.FixParameterTypes(parameters);

                    try
                    {
                        switch (methodName)
                        {
                            case "create_product":
                                objectInstance = (CreateProductCommand)Activator.CreateInstance(typeof(CreateProductCommand), parameters);
                                break;
                            case "get_product_info":
                                objectInstance = (GetProductCommandQuery)Activator.CreateInstance(typeof(GetProductCommandQuery), parameters);
                                break;
                            case "create_order":
                                objectInstance = (CreateOrderCommand)Activator.CreateInstance(typeof(CreateOrderCommand), parameters);
                                break;
                            case "create_campaign":
                                objectInstance = (CreateCampaignCommand)Activator.CreateInstance(typeof(CreateCampaignCommand), parameters);
                                break;
                            case "get_campaign_info":
                                objectInstance = (GetCampaingCommandQuery)Activator.CreateInstance(typeof(GetCampaingCommandQuery), parameters);
                                break;
                            case "increase_time":
                                objectInstance = (IncreaseSystemTimeCommand)Activator.CreateInstance(typeof(IncreaseSystemTimeCommand), parameters);
                                break;
                        }

                        if (objectInstance != null)
                            mediator.Send(objectInstance);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Input not valid !");
                    }
                }
                mediator.Send(new ResetSystemTimeCommand());
            }
        }

        public static IContainer BuildContainer()
        {
            var container = new ContainerBuilder();
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new InfrastructureModule());
            return container.Build();
        }
    }
}
