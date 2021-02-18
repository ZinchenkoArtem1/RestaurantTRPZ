using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class Cook : BaseEntity<int>
    {
        public string Name { get; set; }
        public double Efficiency { get; set; }
    }
}
