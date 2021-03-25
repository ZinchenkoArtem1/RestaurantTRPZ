using RestaurantTRPZ.CMD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTRPZ.CMD.Impl
{
    public class ConsoleDataReader : IDataReader
    {
        public int GetDishId()
        {
            Console.Write("Input dish id: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetTaskNumber()
        {
            Console.Write("Input task number: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
