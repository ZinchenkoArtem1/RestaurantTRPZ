using AutoMapper;
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
        private readonly IMapper _mapper;

        public DishService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unityOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<DishDTO> GetDishesByTypeId(int dishTypeId)
        {
            //ToDo: add to dish repository getByFilter() and some change this method
            IEnumerable<Dish> dishes = _unityOfWork.Dishes.GetAll();
            return dishes.Where(d => d.DishTypeId == dishTypeId)
                .Select(d => _mapper.Map<DishDTO>(d)).ToList();
        }

        public IEnumerable<DishDTO> GetAllDishes()
        {
            IEnumerable<Dish> dishes = _unityOfWork.Dishes.GetAll();
            return dishes.Select(d => _mapper.Map<DishDTO>(d)).ToList(); 
        }
    }
}
