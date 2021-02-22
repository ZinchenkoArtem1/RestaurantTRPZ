using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class EquipmentDishes : BaseEntity<int>
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
