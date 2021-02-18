using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class IngredientsandUnitFullObject
    {
        public int Id { get; set; }
        public int ingredient_Id { get; set; }
        public string ingredient_name { get; set; }
        public int ingredient_genre_id { get; set; }
        public string ingredient_genre_name { get; set; }
        public int unit_Id { get; set; }
        public string unit_name { get; set; }
    }
}
