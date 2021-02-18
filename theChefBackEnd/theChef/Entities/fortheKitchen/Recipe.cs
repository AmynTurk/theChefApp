using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class Recipe
    {
        public int Id { get; set; }
        public int meal_Id { get; set; }
        public string definition { get; set; }
    }
}
