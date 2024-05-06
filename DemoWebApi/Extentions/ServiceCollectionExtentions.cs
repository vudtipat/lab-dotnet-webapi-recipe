using System;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DemoWebApi.Models;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization;
using Microsoft.Extensions.Options;

namespace DemoWebApi.Extentions
{
	public static class ServiceCollectionExtentions
	{
		public static IServiceCollection AddMongoDB(this IServiceCollection services,IConfiguration configuration)
		{
			services.Configure<MongoDBSetting>(configuration.GetSection("MongoDBConnection"));
			services.AddSingleton<IMongoClient>(provider =>
			{
                var settings = provider.GetRequiredService<IOptions<MongoDBSetting>>().Value;
                return new MongoClient(settings.ConnectionString);
            });

			var pack = new ConventionPack();
			pack.Add(new CamelCaseElementNameConvention());

			ConventionRegistry.Register("Custom Conventions",pack,t => true);
            BsonClassMap.RegisterClassMap<Recipe>(cm =>
            {
                cm.AutoMap();
            });
            return services;
		}
	}
}

