using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Entities
{
    public class EquipmentType : BaseEntity<int>
    {
        public string Name { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public TimeSpan SavingStateTime { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
        
        public EquipmentType()
        {
            Equipments = new List<Equipment>();
        }
    }
}
