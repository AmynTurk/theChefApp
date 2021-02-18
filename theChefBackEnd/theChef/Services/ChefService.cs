using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using theChef.Data;
using theChef.Entities.fortheKitchen;
using theChef.Entities.fortheKitchen.fullObjects;

namespace theChef.Services
{
    public interface IChefService
    {
        #region IngredientArea
        #region Ingredient
        Ingredient readIngredient(int Id);
        void addIngredient(Ingredient ingredient);
        void updateIngredient(int Id, Ingredient ingredient);//id veya nesne düzgün gelmezse ingredient nesnesine id'yi gömeceğiz 
        void deleteIngredient(int Id);
        #endregion
        
        #region Ingredient_genre
        Ingredient_genre readIngredient_genre(int Id);
        void addIngredient_genre(Ingredient_genre ingredient_genre);
        void updateIngredient_genre(int Id, Ingredient_genre ingredient_genre);//id veya nesne düzgün gelmezse ingredient nesnesine id'yi gömeceğiz 
        void deleteIngredient_genre(int Id);

        IEnumerable<Ingredient_genre> ingredientGenreList();
        #endregion

        void addIngredientandUnit(IngredientsandUnit ingredientsandUnit);

        IEnumerable<string> provideIngredientFullInfos();

        IngredientFullObject provideFullIngredient(int IngredientId, string IngredientName, int Ingredient_genreId, string Ingredient_genreName);
        #endregion
        
        #region MealArea
        #region Meal
        Meal readMeal(int Id);
        void addMeal(MealFullObject mealFullObject);
        void updateMeal(int Id, MealFullObject mealFullObject);
        void deleteMeal(int Id); 

        IEnumerable<Meal> mealList();

        IEnumerable<string> mealNameList();

        IEnumerable<string> provideMealFullInfosList();
        #endregion

        #region Meal_genre
        Meal_genre readMeal_genre(int Id);
        void addMeal_genre(Meal_genre meal_genre);
        void updateMeal_genre(int Id, Meal_genre meal_genre);
        void deleteMeal_genre(int Id);

        IEnumerable<Meal_genre> mealGenreList();
        #endregion

        #region MealVariation
        MealVariation readMealVariation(int Id);
        void addMealVariation(MealVariation mealVariation);
        void updateMealVariation(int Id, MealVariation mealVariation);//id veya nesne düzgün gelmezse ingredient nesnesine id'yi gömeceğiz 
        void deleteMealVariation(int Id);

        IEnumerable<MealVariation> mealVariationList();
        #endregion

        #region MealswithGenre
        MealswithGenre readMealswithGenre(int Id);
        void addMealswithGenre(MealswithGenre mealswithGenre);
        void updateMealswithGenre(int Id, MealswithGenre mealswithGenre);//id veya nesne düzgün gelmezse ingredient nesnesine id'yi gömeceğiz 
        void deleteMealswithGenre(int Id);
        #endregion

        #region MealandIngredient
        IEnumerable<string> MealandIngredientFullList();

        void addSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients);

        void deleteSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients);

        void updateSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients);
        #endregion

        #region MealandRecipe
        IEnumerable<string> MealandRecipeFullList();

        IEnumerable<string> RecipeFullList();

        void AddRecipe(Recipe recipe);

        void UpdateRecipe(int Id, Recipe recipe);
        #endregion
        #endregion

        #region Unit
        Unit readUnit(int Id);
        void addUnit(Unit unit);
        void updateUnit(int Id, Unit unit);
        void deleteUnit(int Id);

        IEnumerable<Unit> UnitList();
        #endregion
    }

    public class ChefService : IChefService
    {
        private DataContext _dataContext;

        public ChefService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region IngredientArea
        #region Ingredient
        public void addIngredient(Ingredient ingredient)
        {
            ingredient.Id = new int();

            _dataContext.Ingredients.Add(ingredient);
            _dataContext.SaveChanges();
        }
        
        public Ingredient readIngredient(int Id)
        {
            return _dataContext.Ingredients.Find(Id);
        }
        
        public void updateIngredient(int Id, Ingredient ingredient)
        {
            _dataContext.Ingredients.Find(Id).ingredient_genre_id = ingredient.ingredient_genre_id;
            _dataContext.Ingredients.Find(Id).name = ingredient.name;
            _dataContext.SaveChanges();
        }

        public void deleteIngredient(int Id)
        {
            _dataContext.Ingredients.Remove(_dataContext.Ingredients.Find(Id));
            _dataContext.SaveChanges();
        }
        #endregion
        
        #region Ingredient_genre
        public void addIngredient_genre(Ingredient_genre ingredient_genre)
        {
            _dataContext.Add(ingredient_genre);
            _dataContext.SaveChanges();
        }

        public Ingredient_genre readIngredient_genre(int Id)
        {
            return _dataContext.Ingredient_genres.Find(Id);
        }

        public void updateIngredient_genre(int Id, Ingredient_genre ingredient_genre)
        {
            _dataContext.Ingredient_genres.Find(Id).name = ingredient_genre.name;
            _dataContext.SaveChanges();
        }

        public void deleteIngredient_genre(int Id)
        {
            _dataContext.Ingredient_genres.Remove(_dataContext.Ingredient_genres.Find(Id));
            _dataContext.SaveChanges();
        }
        #endregion

        public void addIngredientandUnit(IngredientsandUnit ingredientsandUnit)
        {
            _dataContext.IngredientsandUnits.Add(ingredientsandUnit);

            _dataContext.SaveChanges();
        }

        public IEnumerable<Ingredient_genre> ingredientGenreList()
        {
            return _dataContext.Ingredient_genres;
        }

        public IEnumerable<string> provideIngredientFullInfos()
        {
            var ingredientFullInfoList = new List<string>();

            foreach (var item in _dataContext.Ingredients)
            {
                var ingredientFullInfo = new IngredientFullObject();
                
                ingredientFullInfo.Id = item.Id;
                ingredientFullInfo.name = item.name;
                ingredientFullInfo.ingredient_genre_id = item.ingredient_genre_id;
                ingredientFullInfo.ingredient_genre_name = _dataContext.Ingredient_genres.Find(item.ingredient_genre_id).name;

                ingredientFullInfoList.Add(JsonConvert.SerializeObject(ingredientFullInfo));
            }

            return ingredientFullInfoList;
        }
        
        public IngredientFullObject provideFullIngredient(int _IngredientId, string _IngredientName, int _Ingredient_genreId, string _Ingredient_genreName)
        {
            IngredientFullObject ingredientFullInfo = new IngredientFullObject();
            ingredientFullInfo.Id = _IngredientId;
            ingredientFullInfo.name = _IngredientName;
            ingredientFullInfo.ingredient_genre_id = _Ingredient_genreId;
            ingredientFullInfo.ingredient_genre_name = _Ingredient_genreName;

            return ingredientFullInfo;
        }
        #endregion
        
        #region MealArea
        #region Meal_genre
        public void addMeal_genre(Meal_genre meal_genre)
        {
            _dataContext.Add(meal_genre);
            _dataContext.SaveChanges();
        }

        public Meal_genre readMeal_genre(int Id)
        {
            return _dataContext.Meal_genres.Find(Id);
        }

        public void updateMeal_genre(int Id, Meal_genre meal_genre)
        {
            _dataContext.Meal_genres.Find(Id).name = meal_genre.name;
            _dataContext.SaveChanges();
        }

        public void deleteMeal_genre(int Id)
        {
            _dataContext.Meal_genres.Remove(_dataContext.Meal_genres.Find(Id));
            _dataContext.SaveChanges();
        }

        public IEnumerable<Meal_genre> mealGenreList()
        {
            return _dataContext.Meal_genres;
        }
        
        
        #endregion

        #region Meal
        #region MealRepository
        public void addMeal(MealFullObject mealFullObject)
        {
            Meal meal = new Meal();
            MealVariation mealVariation = new MealVariation();

            bool shouldContinue = true;

            meal.Id = mealFullObject.Id;
            meal.name = mealFullObject.name;

            mealVariation.name = mealFullObject.meal_variation_name;

            foreach (var item in _dataContext.MealVariations)
            {
                if (item.name== mealFullObject.meal_variation_name)
                {
                    meal.meal_variation_id = item.Id;

                    shouldContinue = false;

                    break;
                }
            }

            if (shouldContinue)
            {
                _dataContext.Add(mealVariation);
                _dataContext.SaveChanges();

                meal.meal_variation_id = _dataContext.MealVariations.FirstOrDefault(x => x.name == mealFullObject.meal_variation_name).Id;
            }
            
            _dataContext.Add(meal);
            _dataContext.SaveChanges();
        }

        public Meal readMeal(int Id)
        {
            return _dataContext.Meals.Find(Id);
        }

        public void updateMeal(int Id, MealFullObject mealFullObject)
        {
            Meal meal = new Meal();
            MealVariation mealVariation = new MealVariation();

            bool shouldContinue = true;

            meal.Id = mealFullObject.Id;
            meal.name = mealFullObject.name;

            mealVariation.name = mealFullObject.meal_variation_name;

            foreach (var item in _dataContext.MealVariations)
            {
                if (item.name == mealFullObject.meal_variation_name)
                {
                    meal.meal_variation_id = item.Id;

                    shouldContinue = false;

                    break;
                }
            }

            if (shouldContinue)
            {
                _dataContext.MealVariations.Add(mealVariation);
                _dataContext.SaveChanges();

                meal.meal_variation_id = _dataContext.MealVariations.FirstOrDefault(x => x.name == mealFullObject.meal_variation_name).Id;
            }
            
            _dataContext.Meals.Find(meal.Id).name = meal.name;
            _dataContext.Meals.Find(meal.Id).meal_variation_id = meal.meal_variation_id;
            _dataContext.SaveChanges();
        }

        public void deleteMeal(int Id)
        {
            Meal meal = new Meal();
            meal = _dataContext.Meals.Find(Id);

            _dataContext.Meals.Remove(_dataContext.Meals.Find(Id));
            _dataContext.SaveChanges();

            MealVariation mealVariation = new MealVariation();

            mealVariation = _dataContext.MealVariations.Find(meal.meal_variation_id);

            bool shouldDelete = true;

            foreach (var item in _dataContext.Meals)
            {
                if (item.meal_variation_id==mealVariation.Id)
                {
                    shouldDelete = false;

                    break;
                }
            }
            if (shouldDelete)
            {
                _dataContext.MealVariations.Remove(_dataContext.MealVariations.Find(mealVariation.Id));
                _dataContext.SaveChanges();
            }
        }
        #endregion
        
        public IEnumerable<Meal> mealList()
        {
            return _dataContext.Meals;
        }

        public IEnumerable<string> mealNameList()
        {
            var nameList = new List<string>();

            bool shouldRegister = true;

            foreach (var item in _dataContext.Meals)
            {
                shouldRegister = true;

                foreach (var nameItem in nameList)
                {
                    if (nameItem==item.name)
                    {
                        shouldRegister = false;

                        break;
                    }
                }
                if (shouldRegister)
                {
                    nameList.Add(item.name);
                }
            }

            return nameList;
        }

        public IEnumerable<string> provideMealFullInfosList()
        {
            var mealFullInfoList = new List<string>();

            foreach (var item in _dataContext.Meals)
            {
                var mealFullInfo = new MealFullObject();

                mealFullInfo.Id = item.Id;
                mealFullInfo.name = item.name;
                mealFullInfo.meal_variation_id = item.meal_variation_id;
                mealFullInfo.meal_variation_name = _dataContext.MealVariations.Find(item.meal_variation_id).name;

                mealFullInfoList.Add(JsonConvert.SerializeObject(mealFullInfo));
            }

            return mealFullInfoList;
        }
        #endregion

        #region MealandIngredient
        public IEnumerable<string> MealandIngredientFullList()
        {
            var mealandIngredientFullInfoList = new List<string>();

            foreach (var item in _dataContext.MealsandIngredients)
            {
                var mealandIngredientFullInfo = new MealsandIngredientFullObject();

                mealandIngredientFullInfo.Id = item.Id;
                mealandIngredientFullInfo.ingredient_id = item.ingredient_id;
                mealandIngredientFullInfo.ingredient_name = _dataContext.Ingredients.Find(item.ingredient_id).name;
                mealandIngredientFullInfo.meal_id = item.meal_id;
                mealandIngredientFullInfo.meal_name = _dataContext.Meals.Find(item.meal_id).name;
                mealandIngredientFullInfo.amount = item.amount;

                mealandIngredientFullInfoList.Add(JsonConvert.SerializeObject(mealandIngredientFullInfo));
            }

            return mealandIngredientFullInfoList;
        }

        public void addSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients)
        {
            foreach (var item in mealsandIngredients)
            {
                _dataContext.MealsandIngredients.Add(item);
            }

            _dataContext.SaveChanges();
        }

        public void deleteSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients)
        {
            foreach (var item in mealsandIngredients)
            {
                _dataContext.MealsandIngredients.Remove(_dataContext.MealsandIngredients.Find(item.Id));
            }

            _dataContext.SaveChanges();
        }

        public void updateSomeIngredientstoMealandIngredient(IEnumerable<MealsandIngredient> mealsandIngredients)
        {
            foreach (var item in mealsandIngredients)
            {
                _dataContext.MealsandIngredients.Remove(_dataContext.MealsandIngredients.Find(item.Id));
                //id'si otomatik artansa sorun çıkabilir veya id değişebilir
                _dataContext.MealsandIngredients.Add(item);
            }

            _dataContext.SaveChanges();
        }
        #endregion

        #region MealVariation
        #region MealVariationRepository
        public void addMealVariation(MealVariation mealVariation)
        {
            _dataContext.Add(mealVariation);
            _dataContext.SaveChanges();
        }

        public MealVariation readMealVariation(int Id)
        {
            return _dataContext.MealVariations.Find(Id);
        }

        public void updateMealVariation(int Id, MealVariation mealVariation)
        {
            _dataContext.MealVariations.Find(Id).name = mealVariation.name;
            _dataContext.SaveChanges();
        }

        public void deleteMealVariation(int Id)
        {
            _dataContext.MealVariations.Remove(_dataContext.MealVariations.Find(Id));
            _dataContext.SaveChanges();
        }
        #endregion

        public IEnumerable<MealVariation> mealVariationList()
        {
            return _dataContext.MealVariations;
        }
        #endregion

        #region MealswithGenre
        public void addMealswithGenre(MealswithGenre mealswithGenre)
        {
            _dataContext.Add(mealswithGenre);
            _dataContext.SaveChanges();
        }

        public MealswithGenre readMealswithGenre(int Id)
        {
            return _dataContext.MealswithGenres.Find(Id);
        }

        public void updateMealswithGenre(int Id, MealswithGenre mealswithGenre)
        {
            _dataContext.MealswithGenres.Find(Id).mealGenre_id = mealswithGenre.mealGenre_id;
            _dataContext.MealswithGenres.Find(Id).meal_id = mealswithGenre.meal_id;
            _dataContext.SaveChanges();
        }

        public void deleteMealswithGenre(int Id)
        {
            _dataContext.MealswithGenres.Remove(_dataContext.MealswithGenres.Find(Id));
            _dataContext.SaveChanges();
        }
        #endregion

        #region MealandRecipe
        public IEnumerable<string> MealandRecipeFullList()
        {
            var MealandRecipeFullInfoList = new List<string>();

            foreach (var item in _dataContext.Recipes)
            {
                var mealandRecipeFullInfo = new MealandRecipe();

                mealandRecipeFullInfo.Id = item.Id;
                mealandRecipeFullInfo.meal_id = item.meal_Id;
                mealandRecipeFullInfo.meal_name = _dataContext.Meals.Find(item.meal_Id).name;
                mealandRecipeFullInfo.meal_variation_id =_dataContext.Meals.Find(item.meal_Id).meal_variation_id;
                mealandRecipeFullInfo.meal_variation_name =_dataContext.MealVariations.Find(mealandRecipeFullInfo.meal_variation_id).name;
                mealandRecipeFullInfo.definition = item.definition;

                MealandRecipeFullInfoList.Add(JsonConvert.SerializeObject(mealandRecipeFullInfo));
            }

            return MealandRecipeFullInfoList;
        }


        public IEnumerable<string> RecipeFullList()
        {
            var MealandRecipeFullInfoList = new List<string>();

            foreach (var item in _dataContext.Meals)
            {
                var mealandRecipeFullInfo = new MealandRecipe();

                mealandRecipeFullInfo.Id = item.Id;
                mealandRecipeFullInfo.meal_id = item.Id;
                mealandRecipeFullInfo.meal_name = item.name;
                mealandRecipeFullInfo.meal_variation_id = _dataContext.Meals.Find(item.Id).meal_variation_id;
                mealandRecipeFullInfo.meal_variation_name = _dataContext.MealVariations.Find(mealandRecipeFullInfo.meal_variation_id).name;
                try
                {
                    mealandRecipeFullInfo.definition = _dataContext.Recipes.FirstOrDefault(x =>
                                                    x.meal_Id == item.Id).definition;
                }
                catch (Exception)
                {
                    mealandRecipeFullInfo.definition = "";
                }

                MealandRecipeFullInfoList.Add(JsonConvert.SerializeObject(mealandRecipeFullInfo));
            }

            return MealandRecipeFullInfoList;
        }

        public void AddRecipe(Recipe recipe)
        {
            try
            {
                _dataContext.Recipes.Add(recipe);

                _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                UpdateRecipe(recipe.Id, recipe);
            }
        }

        public void UpdateRecipe(int Id, Recipe recipe)
        {
            _dataContext.Recipes.Find(Id).definition=recipe.definition;

            _dataContext.SaveChanges();
        }
        #endregion
        #endregion

        #region Unit
        public void addUnit(Unit unit)
        {
            _dataContext.Add(unit);
            _dataContext.SaveChanges();
        }

        public Unit readUnit(int Id)
        {
            return _dataContext.Units.Find(Id);
        }

        public void updateUnit(int Id, Unit unit)
        {
            _dataContext.Units.Find(Id).name = unit.name;
            _dataContext.SaveChanges();
        }

        public void deleteUnit(int Id)
        {
            _dataContext.Units.Remove(_dataContext.Units.Find(Id));
            _dataContext.SaveChanges();
        }
        
        public IEnumerable<Unit> UnitList()
        {
            return _dataContext.Units;
        }
        #endregion
    }
}
