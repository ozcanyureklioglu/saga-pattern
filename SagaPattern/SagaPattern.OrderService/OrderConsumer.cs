using MassTransit;
using SagaPattenr.Shared;

namespace SagaPattern.OrderService
{
    public sealed class OrderConsumer(IPublishEndpoint publishEndpoint) : IConsumer<PaymentResult>
    {
        public async Task Consume(ConsumeContext<PaymentResult> context)
        {
            if (context.Message.IsCompleted)
            {
                Console.WriteLine("Order payment is success: " + context.Message.OrderId);
                await publishEndpoint.Publish(new InventoryChange
                {
                    OrderId = context.Message.OrderId,
                    ProductId = context.Message.ProductId
                });
            }
            else
            {
                Console.WriteLine("Order payment is failed: " + context.Message.OrderId);
            }
            await Task.CompletedTask;
        }
    }
}
