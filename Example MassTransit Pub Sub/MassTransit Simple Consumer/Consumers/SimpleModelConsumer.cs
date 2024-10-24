using System.Text.Json;
using MassTransit;
using MassTransit_Pub_Sub_Contracts.Models;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Logging.Console;

namespace MassTransit_Simple_Consumer.Consumers;

public class SimpleModelConsumer : IConsumer<SimpleModel>
{
	public SimpleModelConsumer()
	{
	}

	public Task Consume(ConsumeContext<SimpleModel> context)
	{
		// _logger.LogInformation($"Model consumed: {JsonSerializer.Serialize(context.Message)}");
		
		Console.WriteLine($"Model consumed: {JsonSerializer.Serialize(context.Message)}");
		
		return Task.CompletedTask;
	}
}