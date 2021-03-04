using AutoMapper;
using RestarauntTRPZ.DAL.Abstr.UOW;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.DTO;
using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Services
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork unityOfWork;
        private readonly IMapper mapper;

        public DishService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unityOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<DishDTO> GetAllDishes()
        {
            return unityOfWork.Dishes.GetAll()
                .Select(d => mapper.Map<DishDTO>(d)).ToList();
        }
    }
}
