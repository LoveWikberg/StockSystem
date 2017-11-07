using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtimoTaskLoveWikberg
{
    class StockHandler
    {
        public static int stock = 0;

        public void AddToStock(int numberOfItemsToAdd)
        {
            stock += numberOfItemsToAdd;
        }

        public void RemoveFromStock(int numberOfItemsToSell)
        {
            stock -= numberOfItemsToSell;
            if (stock < 0)
                stock = 0;
        }
    }
}
