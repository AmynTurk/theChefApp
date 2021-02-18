using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace theChef.Entities.fortheKitchen
{
    public class MealsandPicture
    {
        public int Id { get; set; }
        public int meal_id { get; set; }
        //public image picture { get; set; }
        public string definition { get; set; }
    }
}
