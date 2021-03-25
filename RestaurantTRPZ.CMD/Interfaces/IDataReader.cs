using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD.Interfaces
{
    public interface IDataReader
    {
        int GetTaskNumber();

        int GetDishId();
    }
}
