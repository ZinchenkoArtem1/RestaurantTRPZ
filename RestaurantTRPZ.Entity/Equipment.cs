using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Entities
{
    public class Equipment : BaseEntity<int>
    {
        public string Name { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime OffTime { get; set; }
        public TimeSpan PreparingTime { get; set; }
        public TimeSpan SaveStateTime { get; set; }    
    }
}
