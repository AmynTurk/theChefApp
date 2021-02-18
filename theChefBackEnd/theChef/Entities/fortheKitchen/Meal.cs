using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class Meal
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int meal_variation_id { get; set; }
    }
}
