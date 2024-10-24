// using System.Reflection;
// using MassTransit;
// using MassTransit_Pub_Sub_Contracts.Models;
// using MassTransit_Simple_Consumer.Consumers;
//
// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
//
// builder.Services.AddMassTransit(configuration =>
// {
// 	configuration.SetKebabCaseEndpointNameFormatter();
//
// 	configuration.UsingRabbitMq();
//
// 	configuration.AddConsumers(Assembly.GetExecutingAssembly());
// 	
// 	>
// });
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// app.UseSwagger();
// app.UseSwaggerUI();
//
// var summaries = new[]
// {
// 	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
//
// app.Run();


using MassTransit;
using MassTransit_Simple_Consumer.Consumers;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
	cfg.Host("rabbitmq");
	
	cfg.ReceiveEndpoint(configure =>
	{
		configure.Consumer<SimpleModelConsumer>();
	});
});

await busControl.StartAsync(new CancellationToken());
try
{
	Console.WriteLine("Press enter to exit");

	while (true)
	{
		await Task.Delay(100);
	}
}
finally
{
	await busControl.StopAsync();
}