using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestarauntTRPZ.DAL.Abstr.UOW;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.Entities;

namespace RestaurantTRPZ.BLL.Impl.Services
{
    public class CookService : ICookService
    {
        private readonly IUnitOfWork unityOfWork;

        public CookService(IUnitOfWork unitOfWork)
        {
            this.unityOfWork = unitOfWork;
        }

        public Cook GetSuitableCook(DateTime startOrder)
        {
            IEnumerable<Cook> cooks = unityOfWork.Cooks.GetAll();
            IEnumerable<Cook> freeCooks = cooks.Where(dt => startOrder > dt.WhenIsFree).ToList();
            if(freeCooks.Count() == 0)
            {
                return cooks.OrderBy(c => c.WhenIsFree).First();
            }
            return freeCooks.OrderBy(c => c.Efficiency).First();
        }
    }
}
