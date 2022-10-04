// See https://aka.ms/new-console-template for more information
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RequestCardPayment.Consumer;
using RequestCardPayment.Consumer.Consumers;

var builder = new HostBuilder()
    .ConfigureServices(services =>

    {
        services.AddMassTransit(cfg =>
        {
            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq());
            cfg.AddConsumersFromNamespaceContaining<CardPaymentRequestConsumer>();
        });

        services.AddHostedService<MassTransitConsoleHostedService>();
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
    });

await builder.RunConsoleAsync();
