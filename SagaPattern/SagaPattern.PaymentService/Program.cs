using MassTransit;
using SagaPattern.PaymentService;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PaymentConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h => { });
        cfg.ReceiveEndpoint("payment-result", e =>
        {
            e.ConfigureConsumer<PaymentConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
