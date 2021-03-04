using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Abstr.Services
{
    public interface ICookService
    {
        Cook GetSuitableCook(DateTime startOrder);
    }
}
