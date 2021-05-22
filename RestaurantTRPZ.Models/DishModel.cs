using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Models
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; }
        public DishTypeModel DishTypeModel { get; set; }

        public ICollection<IngredientModel> IngredientModels { get; set; }

        public DishModel()
        {
            IngredientModels = new List<IngredientModel>();
        }
    }
}
