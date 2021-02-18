using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class MealsandIngredientFullObject
    {
        public int Id { get; set; }
        public int meal_id { get; set; }
        public string meal_name { get; set; }
        public int ingredient_id { get; set; }
        public string ingredient_name { get; set; }
        public double amount { get; set; }
    }
}
