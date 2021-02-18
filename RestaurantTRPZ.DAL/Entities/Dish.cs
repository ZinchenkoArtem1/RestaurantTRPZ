using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class Dish : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; }
        public DishType DishType { get; set; }

        public IEnumerable<Equipment> Equipments { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
