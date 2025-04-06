using MassTransit;
using SagaPattenr.Shared;

namespace SagaPattern.PaymentService
{
    public sealed class PaymentConsumer(IPublishEndpoint publishEndpoint) : IConsumer<CreateOrder>
    {
        public async Task Consume(ConsumeContext<CreateOrder> context)
        {

            await publishEndpoint.Publish(new PaymentResult {
                IsCompleted = true,
                OrderId = context.Message.OrderId,
                ProductId = context.Message.ProductId                
            });
        }
    }
}
