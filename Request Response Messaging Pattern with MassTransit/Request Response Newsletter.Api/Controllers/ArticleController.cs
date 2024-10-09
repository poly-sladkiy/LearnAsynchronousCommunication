using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Request_Response_Newsletter.Api.Controllers;

[ApiController]
public class ArticleController : ControllerBase
{
	private readonly IRequestClient<GetArticleViewsRequest> _client;

	public ArticleController(IRequestClient<GetArticleViewsRequest> client)
	{
		_client = client;
	}

	public async Task<IActionResult> GetArticle(Guid id)
	{
		var viewsResponse = await _client.GetResponse<GetArticleViewsResponse, ArticleNotFoundResponse>(
			new GetArticleViewsRequest { Id = id });

		long views = 0;
		if (viewsResponse.Is(out Response<GetArticleViewsResponse> viewsResult))
			views = viewsResult.Message.Views;

		var articleResponse = new
		{
			Id = id,
			Name = "test",
			Views = viewsResponse,
		};

		return Ok(articleResponse);
	}
}