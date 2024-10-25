using System.Text.Json;
using MassTransit;
using MassTransit_Pub_Sub_Contracts.Models;

namespace MassTransit_WebApi_Consumer.Consumers;

public class SimpleModelConsumer : IConsumer<SimpleModel>
{

	public Task Consume(ConsumeContext<SimpleModel> context)
	{
		// _logger.LogInformation($"Model consumed: {JsonSerializer.Serialize(context.Message)}");
		
		Console.WriteLine($"Model consumed: {JsonSerializer.Serialize(context.Message)}");
		
		return Task.CompletedTask;
	}
}