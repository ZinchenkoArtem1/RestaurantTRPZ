using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestarauntTRPZ.DAL.Abstr.UOW;
using RestaurantTRPZ.BLL.Abstr.Services;
using RestaurantTRPZ.Entities;

namespace RestaurantTRPZ.BLL.Impl.Services
{
    public class CookService : ICookService
    {
        private readonly IUnitOfWork _unityOfWork;

        public CookService(IUnitOfWork unitOfWork)
        {
            _unityOfWork = unitOfWork;
        }

        public Cook GetSuitableCook(DateTime startOrder)
        {
            IEnumerable<Cook> freeCooks = _unityOfWork.Cooks.GetFreeCooksByWhenIsFreeTime(startOrder);
               
            if (freeCooks.Count() == 0)
            {
                return _unityOfWork.Cooks.GetAllOrderedByWhenIsFreeTime()
                    .First();
            } else {
                return freeCooks
                    .OrderBy(c => c.Efficiency)
                    .First();
            }
        }
    }
}
