using MassTransit;
using SagaPattenr.Shared;

namespace SagaPattern.InventoryService
{
    public sealed class InventoryConsumer : IConsumer<InventoryChange>
    {
        public async Task Consume(ConsumeContext<InventoryChange> context)
        {
            Console.WriteLine($"Change product stok: {context.Message.ProductId}");
            await Task.CompletedTask;
        }
    }
}
