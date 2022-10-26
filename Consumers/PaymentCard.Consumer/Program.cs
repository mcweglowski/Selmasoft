// See https://aka.ms/new-console-template for more information

using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentCard.Consumer.Consumers;

var builder = new HostBuilder()
    .ConfigureServices(services =>
    {
    })
    .ConfigureLogging((hostingContext, logging) => 
    {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
    });

await builder.RunConsoleAsync();
