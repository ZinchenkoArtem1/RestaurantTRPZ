using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.DTO_s
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime OffTime { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public TimeSpan SavingStateTime { get; set; }
    }
}
