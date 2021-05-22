using RestarauntTRPZ.DAL.Abstr.UOW;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.BLL.Impl.Mappers;
using RestaurantTRPZ.Entities;
using RestaurantTRPZ.Models;
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

        public DishService(IUnitOfWork unitOfWork)
        {
            this.unityOfWork = unitOfWork;
        }

        public IEnumerable<DishModel> GetAllDishes()
        {
            return unityOfWork.Dishes.GetAll()
                .Select(d => d.EntityToModel());
        }

        public DishModel GetById(int id)
        {
            return unityOfWork.Dishes.Read(id).EntityToModel();
        }
    }
}
