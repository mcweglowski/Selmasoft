// See https://aka.ms/new-console-template for more information

using MassTransit;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Payments.Contracts.Consumers;
using Payments.Contracts.IntegrationEvents;
using RabbitMQ.Client;
using System.Globalization;

var builder = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumer<BaseIntegrationEventConsumer>();

            cfg.UsingRabbitMq((context, busConfiguration) =>
            {
                busConfiguration.ReceiveEndpoint(endpointConfigurator =>
                {
                    endpointConfigurator.ConfigureConsumeTopology = false;
                    endpointConfigurator.AutoDelete = true;

                    endpointConfigurator.ExchangeType = ExchangeType.Fanout;

                    endpointConfigurator.Bind<BaseIntegrationEvent>(c =>
                    {
                        c.RoutingKey = string.Format(CultureInfo.InvariantCulture, "{0}", "selmasoft.payment.purchase");
                        c.ExchangeType = ExchangeType.Topic;
                    });

                    endpointConfigurator.ConfigureConsumer<BaseIntegrationEventConsumer>(context);
                });
            });

        });
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
    });

await builder.RunConsoleAsync();
