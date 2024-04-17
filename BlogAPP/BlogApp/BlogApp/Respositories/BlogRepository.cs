using BlogApp.Models;
using Elastic.Clients.Elasticsearch;

namespace BlogApp.Respositories;

public class BlogRepository
{
    private readonly ElasticsearchClient client;
    private const string indexName = "blog";

    public BlogRepository(ElasticsearchClient client)
    {
        this.client = client;
    }
    public async Task<Blog> SaveAsync(Blog request)
    {
        request.Crated = DateTime.Now;
        IndexResponse result = await client.IndexAsync(request, i => i.Index(indexName));
        if (!result.IsValidResponse)
            return null;
        request.Id=result.Id.ToString();
        return request;
    }
}
