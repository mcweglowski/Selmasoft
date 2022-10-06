// See https://aka.ms/new-console-template for more information
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RequestCardPayment.Consumer;
using RequestCardPayment.Consumer.Consumers;
using RequestCardPayment.Consumer.Support;

var builder = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

        services.AddMassTransit(cfg =>
        {
            cfg.AddConsumersFromNamespaceContaining<CardPaymentRequestConsumer>();
            cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.ConfigureEndpoints(provider);
            }));
        });

        services.AddSingleton<CounterService>();
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
    });

await builder.RunConsoleAsync();

static IBusControl ConfigureBus(IBusRegistrationContext registrationContext)
{

    return Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.ConfigureEndpoints(registrationContext);
    });
}
