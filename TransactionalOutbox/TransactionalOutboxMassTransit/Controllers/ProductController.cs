using Contracts.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace TransactionalOutboxMassTransit.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
	private readonly IPublishEndpoint _publishEndpoint;

	public ProductController(IPublishEndpoint publishEndpoint)
	{
		_publishEndpoint = publishEndpoint;
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct(ProductCreated product)
	{
		await _publishEndpoint.Publish<ProductCreated>(product);
		
		return Ok(product);
	}
}