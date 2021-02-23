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
        private readonly IUnitOfWork _unityOfWork;

        //ToDo add mapper
        public DishService(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        public DishDTO GetDishById(int dishId)
        {
            Dish dish = _unityOfWork.Dishes.Read(dishId);

            return new DishDTO(); // Map from dish
        }

        public IEnumerable<DishDTO> GetDishesByTypeId(int dishTypeId)
        {
            ICollection<DishDTO> dishDTOs = new List<DishDTO>();

            foreach(Dish dish in _unityOfWork.Dishes.GetAll())
            {
                if(dish.DishTypeId == dishTypeId)
                {
                    dishDTOs.Add(new DishDTO()); // map from dish
                }
            }
            return dishDTOs;
        }

        public IEnumerable<DishDTO> GetAllDishes()
        {
            return new List<DishDTO>(); //_unityOfWork.Dishes.GetAll() map to IEnumerable<DishDTO>
        }
    }
}
