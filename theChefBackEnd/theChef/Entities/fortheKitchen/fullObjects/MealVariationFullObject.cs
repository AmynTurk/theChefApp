using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen.fullObjects
{
    public class MealVariationFullObject
    {
        public int Id { get; set; }
        public int meal_genre_id { get; set; }
        public string meal_genre_name { get; set; }
        public string name { get; set; }
    }
}
