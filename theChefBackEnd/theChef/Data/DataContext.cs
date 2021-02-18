using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using theChef.Entities;
using theChef.Entities.fortheKitchen;
using theChef.Entities.fortheKitchen.fullObjects;

namespace theChef.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Ingredient_genre> Ingredient_genres { get; set; }
        public DbSet<IngredientsandUnit> IngredientsandUnits { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealswithGenre> MealswithGenres { get; set; }
        public DbSet<Meal_genre> Meal_genres { get; set; }
        public DbSet<MealsandIngredient> MealsandIngredients { get; set; }
        public DbSet<MealVariation> MealVariations { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
