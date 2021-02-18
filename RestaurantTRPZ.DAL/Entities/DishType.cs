using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class DishType : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
