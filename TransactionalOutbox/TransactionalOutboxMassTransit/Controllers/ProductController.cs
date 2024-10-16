using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace TransactionalOutboxMassTransit.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProductController : ControllerBase
{
	[HttpPost]
	public async Task<IActionResult> CreateProduct(ProductCreated product)
	{
		return Ok(product);
	}
}