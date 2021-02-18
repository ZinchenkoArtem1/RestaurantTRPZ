using RestaurantTRPZ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.EF
{
    public class RestaurantContext
    {
        ICollection<Dish> Dishes { get; set; }
        ICollection<Order> Orders { get; set; }
        ICollection<Equipment> Equipments { get; set; }
        ICollection<Cook> Cooks { get; set; }
        ICollection<Ingredient> Ingredients { get; set; }

        public RestaurantContext()
        {
            Dishes = new HashSet<Dish>();
            Orders = new HashSet<Order>();
            Equipments = new HashSet<Equipment>();
            Cooks = new HashSet<Cook>();
            Ingredients = new HashSet<Ingredient>();
        }
    }
}
