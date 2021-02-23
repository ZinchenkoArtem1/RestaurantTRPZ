using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class Equipment : BaseEntity<int>
    {
        public string Name { get; set; }
        public DateTime OffTime { get; set; }
        
        public int EquipmentId { get; set; }
        public virtual EquipmentType EquipmentType { get; set; }
    }
}
