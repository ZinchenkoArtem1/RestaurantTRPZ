using RestaurantTRPZ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Entities
{
    public class Dish : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public TimeSpan CookingTime { get; set; }

        public int DishTypeId { get; set; }
        public virtual DishType DishType { get; set; }
        
        public int? EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<DishOrder> DishOrders { get; set; }

        public Dish()
        {
            Ingredients = new List<Ingredient>();
            DishOrders = new List<DishOrder>();
        }
    }
}
