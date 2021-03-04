using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.Entities
{
    public class Cook : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Efficiency { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime WhenIsFree { get; set; }
    }
}
