using Contracts.Models;
using MassTransit;

namespace TransactionalOutboxMassTransit.Consumers;

public class ProductCreatedConsumer : IConsumer<ProductCreated>
{
	private ILogger<ProductCreatedConsumer> _logger;

	public ProductCreatedConsumer(ILogger<ProductCreatedConsumer> logger)
	{
		_logger = logger;
	}

	public Task Consume(ConsumeContext<ProductCreated> context)
	{
		_logger.LogInformation("Product successfully created {@product}", context.Message);
		return Task.CompletedTask;
	}
}