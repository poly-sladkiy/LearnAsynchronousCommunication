namespace Contracts;

public class GetArticleViewsRequest
{
	public Guid Id { get; set; }
}

public class GetArticleViewsResponse
{
	public Guid Id { get; set; }
	public long Views { get; set; }
}

public class ArticleNotFoundResponse
{
	public Guid Id { get; set; }
}