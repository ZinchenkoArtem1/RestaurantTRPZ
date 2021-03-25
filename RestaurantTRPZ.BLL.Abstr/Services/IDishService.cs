using RestaurantTRPZ.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Abstr.Services
{
    public interface IDishService
    {
        IEnumerable<DishDTO> GetAllDishes();

        DishDTO GetById(int id);
    }
}
