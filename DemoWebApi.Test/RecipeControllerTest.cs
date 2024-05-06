using DemoWebApi.Controllers;
using DemoWebApi.Data;
using DemoWebApi.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Test;

public class RecipeControllerTest
{
    [Fact]
    public async void Get_All_Recipes_Correct()
    {
        // arrange
        var allDataCount = 5;
        var fakeRecipe = A.CollectionOfDummy<Recipe>(allDataCount).ToList();        
        var mockDataStore = A.Fake<IRecipeDataStore>();        
        A.CallTo(() => mockDataStore.GetAsync()).Returns(Task.FromResult(fakeRecipe));
        
        var controller = new RecipesController(mockDataStore);

        // act

        var actionResult = await controller.GetRecipesAsync(null);

        // assert

        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        var resultRecipes = Assert.IsAssignableFrom<ResponseEntity>(okResult.Value);
        var returnedRecipes = Assert.IsAssignableFrom<List<Recipe>>(resultRecipes.Data);
        Assert.Equal(allDataCount, returnedRecipes.Count());
    }

    [Fact]
    public async void Get_All_Recipes_Not_Correct()
    {
        // arrange
        var allDataCount = 5;
        var fakeRecipe = A.CollectionOfDummy<Recipe>(allDataCount).ToList();
        var mockDataStore = A.Fake<IRecipeDataStore>();
        A.CallTo(() => mockDataStore.GetAsync()).Returns(Task.FromResult(fakeRecipe));

        var controller = new RecipesController(mockDataStore);

        // act

        var actionResult = await controller.GetRecipesAsync(null);

        // assert

        var okResult = Assert.IsType<OkObjectResult>(actionResult);
        var resultRecipes = Assert.IsAssignableFrom<ResponseEntity>(okResult.Value);
        var returnedRecipes = Assert.IsAssignableFrom<List<Recipe>>(resultRecipes.Data);
        Assert.NotEqual(3, returnedRecipes.Count());
    }
}
