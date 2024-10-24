using Contracts.Models;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.EntityFrameworkCore;
using TransactionalOutboxMassTransit;
using TransactionalOutboxMassTransit.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OutboxDbContext>(options =>
{
	options.UseNpgsql("Host=postgresql;User ID=postgres;Password=password;Database=outbox;Port=5432;");
});

builder.Services.AddMassTransit(config =>
{
	config.SetKebabCaseEndpointNameFormatter();
	
	config.AddConsumer<ProductCreatedConsumer>();
	
	config.UsingRabbitMq();
	
	config.AddEntityFrameworkOutbox<OutboxDbContext>(options =>
	{
		options.UsePostgres();
		options.UseBusOutbox();
	});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetService<OutboxDbContext>();
	
	if (db.Database.GetPendingMigrations().Any())
		db.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
