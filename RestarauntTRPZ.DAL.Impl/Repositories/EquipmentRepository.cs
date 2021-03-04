using RestarauntTRPZ.DAL.Abstr.Repositories;
using RestarauntTRPZ.DAL.Impl.EF;
using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Impl.Repositories
{
    public class EquipmentRepository : GenericRepository<Equipment, int>, IEquipmentRepository
    {
        public EquipmentRepository(RestaurantContext context) : base(context)
        {

        }
    }
}
