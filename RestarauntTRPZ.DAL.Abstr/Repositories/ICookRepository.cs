using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestarauntTRPZ.DAL.Abstr.Repositories
{
    public interface ICookRepository : IGenericRepository<Cook, int>
    {
        IEnumerable<Cook> GetFreeCooksByWhenIsFreeTime(DateTime startOrder);
        IEnumerable<Cook> GetAllOrderedByWhenIsFreeTime();
    }
}
