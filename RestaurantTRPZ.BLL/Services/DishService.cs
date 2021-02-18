using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public DishDTO GetDishById(int dishId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DishDTO> GetDishesByTypeId(int dishTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
