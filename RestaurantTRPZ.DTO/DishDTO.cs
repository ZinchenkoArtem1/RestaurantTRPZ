using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DTO
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; }
        public string DishTypeName { get; set; }

        public ICollection<IngredientDTO> IngredientDTOs { get; set; }

        public DishDTO()
        {
            IngredientDTOs = new List<IngredientDTO>();
        }
    }
}
