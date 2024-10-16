namespace Contracts.Models;

public record ProductCreated(Guid Id, string Name, decimal Price, string? Description);