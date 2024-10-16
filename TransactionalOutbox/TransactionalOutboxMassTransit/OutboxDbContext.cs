using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace TransactionalOutboxMassTransit;

public class OutboxDbContext : DbContext
{
	public OutboxDbContext(DbContextOptions<OutboxDbContext> options) : base(options)
	{
		
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.AddInboxStateEntity();
		modelBuilder.AddOutboxMessageEntity();
		modelBuilder.AddOutboxStateEntity();
	}
}