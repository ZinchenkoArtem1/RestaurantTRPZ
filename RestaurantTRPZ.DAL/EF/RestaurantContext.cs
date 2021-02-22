using RestaurantTRPZ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.EF
{
    /*
     ToDo Connect EF 
    */

    public class RestaurantContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<DishType> DishTypes { get; set; }

        public RestaurantContext() : base("RestaurantDBConnection")
        {

        }
    }
}
