using RestaurantTRPZ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.DAL.Repositories.Interfaces
{
    public interface ICookRepository : IRepository<Cook, int>
    {
        Cook GetFreeCook(); 
    }
}
