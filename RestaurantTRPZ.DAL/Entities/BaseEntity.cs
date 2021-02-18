﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public abstract class BaseEntity<TKey> 
    {
        public TKey Id { get; set; }
    }
}
