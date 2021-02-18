using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class IngredientFullObject
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int ingredient_genre_id { get; set; }
        public string ingredient_genre_name { get; set; }
    }
}
