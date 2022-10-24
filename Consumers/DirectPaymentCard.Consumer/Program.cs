// See https://aka.ms/new-console-template for more information
using DirectPaymentCard.Consumer.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = new HostBuilder()
    .ConfigureServices(services => 
    {
        services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumersFromNamespaceContaining<DirectCardPaymentConsumer>();
            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ConfigureEndpoints(provider);
            }));
        });
    })
    .ConfigureLogging((hotingContext, logging) => 
    {
        logging.AddConfiguration(hotingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
    });

await builder.RunConsoleAsync();