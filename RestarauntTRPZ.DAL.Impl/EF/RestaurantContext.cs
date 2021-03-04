﻿using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl.EF
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Orders { get; set; }

        public RestaurantContext(string NameOrConnectionStringName) : base(NameOrConnectionStringName) {
            Database.SetInitializer<RestaurantContext>(new DbInitializer());
        }
    }
}