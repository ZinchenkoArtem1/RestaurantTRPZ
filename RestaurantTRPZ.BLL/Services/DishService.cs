using RestaurantTRPZ.BLL.DTO_s;
using RestaurantTRPZ.BLL.Services.Interfaces;
using RestaurantTRPZ.DAL.Entities;
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
            Dish dish = _dishRepository.Read(dishId);

            return new DishDTO(); // Map from dish
        }

        public IEnumerable<DishDTO> GetDishesByTypeId(int dishTypeId)
        {
            ICollection<DishDTO> dishDTOs = new List<DishDTO>();

            foreach(Dish dish in _dishRepository.GetAll())
            {
                if(dish.DishTypeId == dishTypeId)
                {
                    dishDTOs.Add(new DishDTO()); // map from dish
                }
            }
            return dishDTOs;
        }
    }
}
