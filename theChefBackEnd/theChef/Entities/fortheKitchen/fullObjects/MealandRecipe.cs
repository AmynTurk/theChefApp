using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen.fullObjects
{
    public class MealandRecipe
    {
        public int Id { get; set; }

        public int meal_id { get; set; }
        public string meal_name { get; set; }

        public int meal_variation_id { get; set; }
        public string meal_variation_name { get; set; }

        public string definition { get; set; }
    }
}
