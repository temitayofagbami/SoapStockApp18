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
        public static Order CreateOrder(string custName, string custEmailAddress, string custAddress, string custPhoneNumber, List<Product> orderedproduct)

        {

           var order = new Order
            {


            };
            

            var customer = new Customer
            {

                CustomerName = custName,
                CustomerEmail = custEmailAddress,
                CustomerAddr = custAddress,
                CustomerPhone = custPhoneNumber,

            };
            Console.WriteLine(" begore adding customer");
            db.Customers.Add(customer);
            Console.WriteLine(" afteradding");
            db.SaveChanges();
            Console.WriteLine(" aftercommiting");

            //db.Orders.Add(order);
            return order;
        }

       

    }
}
