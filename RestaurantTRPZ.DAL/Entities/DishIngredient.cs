using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class DishIngredient : BaseEntity<int>
    {
        public double Weight { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
