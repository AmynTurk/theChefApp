using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class MealFullObject
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int meal_variation_id { get; set; }
        public string meal_variation_name { get; set; }
    }
}
