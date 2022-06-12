using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace EShop.Infrastructure.Mongo
{
    public static class Extension
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("Mongo")["ConnectionString"];
            var database = configuration.GetSection("Mongo")["Database"];

            services.AddSingleton<IMongoClient>(client => new MongoClient(connectionString));

            services.AddSingleton<IMongoDatabase>(client => {
                var mongoClient = client.GetService<IMongoClient>();
                return mongoClient.GetDatabase(database);
            });

            services.AddSingleton<MongoInitializer>();
        }
    }
}