using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using theChef.Entities;
using theChef.Entities.fortheKitchen;
using theChef.Services;

namespace theChef.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = Role.Chef)]
    public class ChefController : ControllerBase
    {
        private IChefService _chefService;

        public ChefController(IChefService chefService)
        {
            _chefService = chefService;
        }
        
        #region IngredientArea
        #region Ingredient
        // POST: api/Chef
        [HttpGet]
        public IActionResult readIngredient(int Id)
        {
            var ingredient = _chefService.readIngredient(Id);

            return Ok(JsonConvert.SerializeObject(_chefService.provideFullIngredient(ingredient.Id, ingredient.name, ingredient.ingredient_genre_id, _chefService.readIngredient_genre(ingredient.ingredient_genre_id).name)));
        }

        // POST: api/Chef
        [HttpPost]
        public IActionResult addIngredient([FromBody] Ingredient ingredient)
        {
            _chefService.addIngredient(ingredient);

            return Ok("successful!");
        }

        // PUT: api/Chef/5
        [HttpPut("{id}")]
        public IActionResult updateIngredient(int Id, [FromBody] Ingredient ingredient)
        {
            _chefService.updateIngredient(Id, ingredient);

            return Ok("successful!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteIngredient(int Id)
        {
            _chefService.deleteIngredient(Id);

            return Ok("successful!");
        }

        [HttpGet]
        public IActionResult IngredientList()
        {
            return Ok("_chefService.ingredientGenreList()");
        }
        #endregion
        
        #region Ingredient Genre
        // POST: api/Chef
        [HttpGet]
        public IActionResult readIngredient_genre(int Id)
        {
            return Ok(JsonConvert.SerializeObject(_chefService.readIngredient_genre(Id)));
        }

        // POST: api/Chef
        [HttpPost]
        public IActionResult addIngredient_genre([FromBody] Ingredient_genre ingredient_Genre)
        {
            _chefService.addIngredient_genre(ingredient_Genre);

            return Ok("successful!");
        }

        // PUT: api/Chef/5
        [HttpPut("{id}")]
        public IActionResult updateIngredient_genre(int Id, [FromBody] Ingredient_genre ingredient_Genre)
        {
            _chefService.updateIngredient_genre(Id, ingredient_Genre);

            return Ok("successful!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteIngredient_genre(int Id)
        {
            _chefService.deleteIngredient_genre(Id);

            return Ok("successful!");
        }

        [HttpGet]
        public IActionResult Ingredient_genreList()
        {
            string[] array = new string[_chefService.ingredientGenreList().ToArray().Length];

            int i = 0;

            foreach (var item in _chefService.ingredientGenreList())
            {
                array[i] = JsonConvert.SerializeObject(item);

                i++;
            }

            return Ok(array);
        }
        #endregion

        [HttpGet]
        public IActionResult provideIngredientFullInfos()
        {
            return Ok(_chefService.provideIngredientFullInfos());
        }
        #endregion

        #region MealArea
        #region Meal Genre
        // POST: api/Chef
        [HttpGet]
        public IActionResult readMeal_genre(int Id)
        {
            return Ok(JsonConvert.SerializeObject(_chefService.readMeal_genre(Id)));
        }

        // POST: api/Chef
        [HttpPost]
        public IActionResult addMeal_genre([FromBody] Meal_genre meal_genre)
        {
            _chefService.addMeal_genre(meal_genre);

            return Ok("successful!");
        }

        // PUT: api/Chef/5
        [HttpPut("{id}")]
        public IActionResult updateMeal_genre(int Id, [FromBody] Meal_genre meal_genre)
        {
            _chefService.updateMeal_genre(Id, meal_genre);

            return Ok("successful!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteMeal_genre(int Id)
        {
            _chefService.deleteMeal_genre(Id);

            return Ok("successful!");
        }

        [HttpGet]
        public IActionResult Meal_genreList()
        {
            string[] array = new string[_chefService.mealGenreList().ToArray().Length];

            int i = 0;

            foreach (var item in _chefService.mealGenreList())
            {
                array[i] = JsonConvert.SerializeObject(item);

                i++;
            }

            return Ok(array);
        }
        #endregion

        #region MealVariation
        // POST: api/Chef
        [HttpGet]
        public IActionResult readMealVariation(int Id)
        {
            return Ok(JsonConvert.SerializeObject(_chefService.readMealVariation(Id)));
        }

        // POST: api/Chef
        [HttpPost]
        public IActionResult addMealVariation([FromBody] MealVariation mealVariation)
        {
            _chefService.addMealVariation(mealVariation);

            return Ok("successful!");
        }

        // PUT: api/Chef/5
        [HttpPut("{id}")]
        public IActionResult updateMealVariation(int Id, [FromBody] MealVariation mealVariation)
        {
            _chefService.updateMealVariation(Id, mealVariation);

            return Ok("successful!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteMealVariation(int Id)
        {
            _chefService.deleteMealVariation(Id);

            return Ok("successful!");
        }

        [HttpGet]
        public IActionResult MealVariationList()
        {
            string[] array = new string[_chefService.mealVariationList().ToArray().Length];

            int i = 0;

            foreach (var item in _chefService.mealVariationList())
            {
                array[i] = JsonConvert.SerializeObject(item);

                i++;
            }

            return Ok(array);
        }
        #endregion

        #region Meal
        // POST: api/Chef
        [HttpGet]
        public IActionResult readMeal(int Id)
        {
            return Ok(JsonConvert.SerializeObject(_chefService.readMeal(Id)));
        }

        // POST: api/Chef
        [HttpPost]
        public IActionResult addMeal([FromBody] MealFullObject mealFullObject)
        {
            _chefService.addMeal(mealFullObject);

            return Ok("successful!");
        }

        // PUT: api/Chef/5
        [HttpPut("{id}")]
        public IActionResult updateMeal(int Id, [FromBody] MealFullObject mealFullObject)
        {
            _chefService.updateMeal(Id, mealFullObject);

            return Ok("successful!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteMeal(int Id)
        {
            _chefService.deleteMeal(Id);

            return Ok("successful!");
        }

        [HttpGet]
        public IActionResult MealList()
        {
            string[] array = new string[_chefService.mealList().ToArray().Length];

            int i = 0;

            foreach (var item in _chefService.mealList())
            {
                array[i] = JsonConvert.SerializeObject(item);

                i++;
            }

            return Ok(array);
        }

        [HttpGet]
        public IActionResult mealNameList()
        {
            return Ok(_chefService.mealNameList());
        }

        [HttpGet]
        public IActionResult MealFullList()
        {
            return Ok(_chefService.provideMealFullInfosList());
        }
        #endregion

        #region MealandIngredient
        [HttpGet]
        public IActionResult MealandIngredientFullList()
        {
            return Ok(_chefService.MealandIngredientFullList());
        }

        [HttpPost]
        public IActionResult addSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients)
        {
            _chefService.addSomeIngredientstoMealandIngredient(mealsandIngredients);

            return Ok("successful!");
        }

        [HttpPost]
        public IActionResult deleteSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients)
        {
            _chefService.deleteSomeIngredientstoMealandIngredient(mealsandIngredients);

            return Ok("successful!");
        }
        #endregion

        #region MealandRecipe
        [HttpGet]
        public IActionResult MealandRecipeFullList()
        {
            return Ok(_chefService.MealandIngredientFullList());
        }
        
        [HttpGet]
        public IActionResult RecipeFullList()
        {
            return Ok(_chefService.RecipeFullList());
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {
            _chefService.AddRecipe(recipe);

            return Ok("successful!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRecipe(int Id, Recipe recipe)
        {
            _chefService.UpdateRecipe(Id, recipe);

            return Ok("successful!");
        }
        #endregion
        #endregion

        #region UnitArea
        // POST: api/Chef
        [HttpGet]
        public IActionResult readUnit(int Id)
        {
            return Ok(JsonConvert.SerializeObject(_chefService.readUnit(Id)));
        }

        // POST: api/Chef
        [HttpPost]
        public IActionResult addUnit([FromBody] Unit unit)
        {
            _chefService.addUnit(unit);

            return Ok("successful!");
        }

        // PUT: api/Chef/5
        [HttpPut("{id}")]
        public IActionResult updateUnit(int Id, [FromBody] Unit unit)
        {
            _chefService.updateUnit(Id, unit);

            return Ok("successful!");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteUnit(int Id)
        {
            _chefService.deleteUnit(Id);

            return Ok("successful!");
        }

        [HttpGet]
        public IActionResult UnitList()
        {
            string[] array = new string[_chefService.UnitList().ToArray().Length];

            int i = 0;

            foreach (var item in _chefService.UnitList())
            {
                array[i] = JsonConvert.SerializeObject(item);

                i++;
            }

            return Ok(array);
        }
        #endregion
    }
}
