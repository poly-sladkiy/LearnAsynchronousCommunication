using MassTransit;
using MassTransit_Pub_Sub_Contracts.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configuration =>
{
	configuration.SetKebabCaseEndpointNameFormatter();
	configuration.UsingRabbitMq();
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost("/simple", async (SimpleModel model, IPublishEndpoint endpoint) =>
	{
		await endpoint.Publish(model);
		
		return model;
	})
	.WithName("PublishSimpleModel")
	.WithOpenApi();

app.Run();
