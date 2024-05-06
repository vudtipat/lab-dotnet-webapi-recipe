using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApi.Data;
using DemoWebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

/*
Binding Source
Request Body            => [FromBody]
Form Data in req body   => [FromForm]
Header                  => [FromHeader]
Query String            => [FromQuery]
*/

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : Controller
    {
        private readonly IRecipeDataStore _recipeDataStore;

        public RecipesController(IRecipeDataStore recipeDataStore)
        {
            _recipeDataStore = recipeDataStore;
        }

        [HttpGet]
        public async Task<ActionResult> GetRecipesAsync([FromQuery] int? count)
        {
            var recipes = await _recipeDataStore.GetAsync();
            var response = new ResponseEntity();
            
            if (count != null) response.Data = recipes.Take(count.Value);
            else response.Data = recipes;

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewRecipes([FromBody] Recipe newRecipe)
        {
            await _recipeDataStore.CreateAsync(newRecipe);

            var response = new ResponseEntity();
            return Created("", response);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRecipe(string id, JsonPatchDocument<Recipe> recipeUpdates)
        {
            // this action we can use alternative way by use HTTP.PUT and pass value from body then update only changed value
            var recipe = await _recipeDataStore.GetAsync(id);

            if(recipe == null)
            {
                return NotFound();
            }

            recipeUpdates.ApplyTo(recipe);
            await _recipeDataStore.UpdateAsync(id,recipe);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecipes(string id)
        {
            await _recipeDataStore.RemoveAsync(id);

            return NoContent();
        }
    }
}

