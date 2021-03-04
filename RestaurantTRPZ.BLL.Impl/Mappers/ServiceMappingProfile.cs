using AutoMapper;
using RestaurantTRPZ.DTO;
using RestaurantTRPZ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.BLL.Impl.Mappers
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Dish, DishDTO>()
                .ForMember(dt => dt.IngredientDTOs, opt => opt.MapFrom(d => d.DishIngredients.Select(di => di.Ingredient).ToList()))
                .ForMember(dt => dt.DishTypeName, opt => opt.MapFrom(dt => dt.DishType.Name));
            CreateMap<DishDTO, Dish>()
                .ForMember(d => d.DishIngredients, opt => opt.Ignore())
                .ForMember(d => d.DishType, opt => opt.Ignore())
                .ForMember(d => d.Equipment, opt => opt.Ignore());
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Order, OrderDTO>()
                .ForMember(od => od.DishOrderDTOs, opt => opt.MapFrom(o => o.DishOrders));
            CreateMap<OrderDTO, Order>()
                .ForMember(o => o.DishOrders, opt => opt.MapFrom(od => od.DishOrderDTOs));
            CreateMap<DishOrder, DishOrderDTO>()
                .ForMember(dot => dot.DishDTO, opt => opt.MapFrom(d => d.DishId));
            CreateMap<DishOrderDTO, DishOrder>()
                .ForMember(d => d.Cook, opt => opt.Ignore())
                .ForMember(d => d.Dish, opt => opt.MapFrom(dot => dot.DishDTO));
        }
    }
}
