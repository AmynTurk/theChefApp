using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class MealsandIngredient
    {
        public int Id { get; set; }
        public int meal_id { get; set; }
        public int ingredient_id { get; set; }
        public double amount { get; set; }
    }
}
