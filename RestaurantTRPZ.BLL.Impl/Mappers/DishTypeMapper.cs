using RestaurantTRPZ.Entities;
using RestaurantTRPZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Mappers
{
    public static class DishTypeMapper
    {
        public static DishType ModelToEntity(this DishTypeModel dishTypeModel)
        {
            return new DishType()
            {
                Id = dishTypeModel.Id,
                Name = dishTypeModel.Name,

            };
        }

        public static DishTypeModel EntityToModel(this DishType dishType)
        {
            return new DishTypeModel()
            {
                Id = dishType.Id,
                Name = dishType.Name,

            };
        }
    }
}
