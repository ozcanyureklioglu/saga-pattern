var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.SagaPattern_OrderService>("sagapattern-orderservice");

builder.AddProject<Projects.SagaPattern_PaymentService>("sagapattern-paymentservice");

builder.AddProject<Projects.SagaPattern_InventoryService>("sagapattern-inventoryservice");

builder.Build().Run();
