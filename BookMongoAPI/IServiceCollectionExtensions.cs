using BookMongoAPI.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BookMongoAPI
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var client = new MongoClient(configuration["BookstoreDatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["BookstoreDatabaseSettings:DatabaseName"]);
            services.AddSingleton<IMongoDatabase>(database); // MongoDB say MongoClient should be a singleton.
            services.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
