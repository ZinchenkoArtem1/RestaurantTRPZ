using AutoMapper;
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
    public class CookQueueService : ICookQueueService
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public CookQueueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unityOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Cook GetSuitableCook()
        {
            return _unityOfWork.Cooks.GetAll().ToList().OrderBy(ck => ck.Efficiency).Last();
        }
    }
}
