using MassTransit;
using SagaPattenr.Shared;
using SagaPattern.OrderService;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>{ });
        cfg.ReceiveEndpoint("order-payment-result", e =>
        {
            e.ConfigureConsumer<OrderConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/create-order", async (IPublishEndpoint publishEnpoint) => 
{
    await publishEnpoint.Publish(new CreateOrder());
    return Results.Created();
});

app.Run();
