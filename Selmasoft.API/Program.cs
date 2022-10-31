using MassTransit;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Payments.Contracts;
using Payments.Contracts.IntegrationEvents;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

// Add services to the container.
builder.Services.AddMassTransit(cfg =>
{
    cfg.UsingRabbitMq((_, config) => 
    {        
        config.Send<BaseIntegrationEvent>(sendTopology => {
            sendTopology.UseRoutingKeyFormatter(x => x.Message.EventType);
        });

        config.Publish<BaseIntegrationEvent>(publishTopology => 
        {
            publishTopology.ExchangeType = ExchangeType.Topic;
        });
    });

    //cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq());
    cfg.AddRequestClient<CardPaymentRequest>();
    cfg.AddRequestClient<CashPaymentRequest>();
    cfg.AddRequestClient<DirectCardPaymentRequest>();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
