using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen.fullObjects
{
    public class MealswithGenreFullObject
    {
        public int Id { get; set; }
        public int meal_id { get; set; }
        public string meal_name { get; set; }
        public int mealGenre_id { get; set; }
        public string mealGenre_name { get; set; }
    }
}
