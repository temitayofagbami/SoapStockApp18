using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{

    class Store
    {
        
        private static SoapStockModel db = new SoapStockModel();

        //Create new order
        public static Order CreateOrder(List<Product> selectedproduct)

        {

            var order = new Order
            {
                

            };

            //db.Orders.Add(order)
            return order;
        }
        //Create new customer

    }
}
