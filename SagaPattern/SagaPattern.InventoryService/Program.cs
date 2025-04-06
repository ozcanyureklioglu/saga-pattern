using MassTransit;
using SagaPattern.InventoryService;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<InventoryConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h => { });
        cfg.ReceiveEndpoint("inventory-change", e =>
        {
            e.ConfigureConsumer<InventoryConsumer>(context);
        });
    });
});
var app = builder.Build();

app.Run();
