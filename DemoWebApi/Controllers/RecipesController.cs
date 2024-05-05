using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        public ActionResult GetRecipes([FromQuery]int count)
        {
            string[] recipes = {"Oxtail", "Curry Chicken", "Dumpling"};

            if (!recipes.Any())
            {
                return NotFound();
            }
            return Ok(recipes.Take(count));
        }

        //[HttpPost]
        //public ActionResult CreateNewRecipes()
        //{
        //    bool badThingHappen = false;

        //    string[] recipes = { "Oxtail", "Curry Chicken", "Dumpling" };

        //    if (badThingHappen)
        //    {
        //        return BadRequest();
        //    }

        //    return ;
        //}

        [HttpDelete("{id}")]
        public ActionResult DeleteRecipes(string id)
        {
            bool badThingHappen = false;

            if (badThingHappen)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}

