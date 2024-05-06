using System;
using DemoWebApi.Models;

namespace DemoWebApi.Data
{
	public interface IRecipeDataStore
	{
        Task<List<Recipe>> GetAsync();

        Task<Recipe?> GetAsync(string recipeID);

        Task CreateAsync(Recipe newRecipe);

        Task UpdateAsync(string recipeID, Recipe updatedRecipe);

        Task RemoveAsync(string recipeID);
    }
}

