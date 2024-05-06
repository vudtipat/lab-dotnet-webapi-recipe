using System;
using DemoWebApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DemoWebApi.Data
{
	public class RecipeDataStore: IRecipeDataStore
	{
		private readonly IMongoClient _mongoClient;
		private readonly MongoDBSetting _mongoSetting;
		private readonly IMongoDatabase _mongoDatabass;
		private readonly IMongoCollection<Recipe> _recipeCollection;	

		public RecipeDataStore(
                IMongoClient mongoClient,
                IOptions<MongoDBSetting> mongoSetting
			)
		{
            _mongoClient = mongoClient;
			_mongoSetting = mongoSetting.Value;
            _mongoDatabass = mongoClient.GetDatabase(_mongoSetting.DatabaseName);
            _recipeCollection = _mongoDatabass.GetCollection<Recipe>(_mongoSetting.CollectionName);
        }

        public async Task<List<Recipe>> GetAsync() => await _recipeCollection.Find(_ => true).ToListAsync();

        public async Task<Recipe?> GetAsync(string recipeID) => await _recipeCollection.Find(x => x.RecipeId == recipeID).FirstOrDefaultAsync();

        public async Task CreateAsync(Recipe newRecipe) => await _recipeCollection.InsertOneAsync(newRecipe);

        public async Task UpdateAsync(string recipeID, Recipe updatedRecipe) => await _recipeCollection.ReplaceOneAsync(x => x.RecipeId == recipeID, updatedRecipe);

        public async Task RemoveAsync(string recipeID) => await _recipeCollection.DeleteOneAsync(x => x.RecipeId == recipeID);

    }
}

