﻿using Elastic.Clients.Elasticsearch;
using Elastic.Transport;



namespace BlogApp.Extensions;

public static class ElasticSearchExt
{
    public static void AddElasticClient(this IServiceCollection services,IConfiguration configuration)
    {
        var userName = (configuration.GetSection("Elastic")["UserName"]!);
        var password = (configuration.GetSection("Elastic")["Password"]!);
        var settings = new ElasticsearchClientSettings(new Uri(configuration.GetSection("Elastic")["Url"]!)).Authentication(new BasicAuthentication(userName,password));
       
        var client=new ElasticsearchClient(settings);
        //var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));

        //var settings = new ConnectionSettings(pool);
        //var client = new ElasticClient(settings);
       services.AddSingleton(client);
    }
}
