using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen.fullObjects
{
    public class RecipeFullObject
    {
        public int Id { get; set; }
        public int meal_Id { get; set; }
        public string meal_name { get; set; }
        public string definition { get; set; }
    }
}
