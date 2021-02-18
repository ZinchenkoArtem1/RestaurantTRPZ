using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.DTO
{
    public class DishDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; }

        public DishTypeDTO DishType { get; set; }

        public IEnumerable<IngredientDTO> Ingredients { get; set; }
    }
}
