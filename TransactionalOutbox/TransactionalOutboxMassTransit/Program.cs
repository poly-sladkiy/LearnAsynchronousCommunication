using MassTransit;
using Microsoft.EntityFrameworkCore;
using TransactionalOutboxMassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OutboxDbContext>(options =>
{
	options.UseNpgsql();
});

builder.Services.AddMassTransit(config =>
{
	config.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host("rabbit", "/", h =>
		{
			h.Username("guest");
			h.Password("guest");
		});

	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
