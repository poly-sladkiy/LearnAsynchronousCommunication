using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Newsletter.Reporting.Api.Features.Articles;

public class GetArticleViewsConsumer : IConsumer<GetArticleViewsRequest>
{
	public async Task Consume(ConsumeContext<GetArticleViewsRequest> context)
	{
		if (Random.Shared.Next() % 2 == 0)
		{
			await context.RespondAsync(new ArticleNotFoundResponse { Id = context.Message.Id });
			return;
		}

		var views = Random.Shared.NextInt64(0, int.MaxValue);

		var response = new GetArticleViewsResponse
		{
			Id = context.Message.Id,
			Views = views
		};

		await context.RespondAsync(response);
	}
}