using RestaurantTRPZ.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Services.Interfaces
{
    public interface IOrderTimeCalculationService 
    {
        DateTime countOrderTime(DateTime startOrder, Dish dish, Equipment equipment, Cook cook);
    }
}
