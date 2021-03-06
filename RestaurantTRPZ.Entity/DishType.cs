﻿using RestaurantTRPZ.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Entities
{
    public class DishType : BaseEntity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }

        public DishType()
        {
            Dishes = new List<Dish>();
        }
    }
}
