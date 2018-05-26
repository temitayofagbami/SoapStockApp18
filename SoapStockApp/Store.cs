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
        public static void CreateOrder(string custName, string custEmailAddress, string custAddress, string custPhoneNumber, List<Product> orderedproduct)

        {

            if (string.IsNullOrEmpty(custName))
            {
                throw new ArgumentNullException(" the customer name was not provided");
            }
            if (string.IsNullOrEmpty(custEmailAddress))
            {
                throw new ArgumentNullException(" the customer email was not provided");
            }
            if (string.IsNullOrEmpty(custAddress))
            {
                throw new ArgumentNullException(" the customer address was not provided");
            }
            if (string.IsNullOrEmpty(custPhoneNumber))
            {
                throw new ArgumentNullException(" the customer address was not provided");
            }
            if (orderedproduct.ToArray().Length == 0)
            {
                throw new ArgumentNullException(" No products were ordered");
            }

            var customer = new Customer
            {

                CustomerName = custName,
                CustomerEmail = custEmailAddress,
                CustomerAddr = custAddress,
                CustomerPhone = custPhoneNumber,

            };
           
            db.Customers.Add(customer);
            db.SaveChanges();
        
            //create order detail
            var orderdetail = new OrderDetail
            {

            };
            db.OrderDetails.Add(orderdetail);
            db.SaveChanges();

            //create order from list of ordered products
            for (int i=0; i < orderedproduct.Count; i++) {

                var order = new Order
                {

                    CustomerNumber = customer.CustomerID,
                    ProductNumber = orderedproduct[i].ProductID,
                    OrderDetailNumber = orderdetail.OrderDetailID,
                    OrderQuantity = orderedproduct[i].ProductQuantity,
                    OrderPrice = orderedproduct[i].ProductPrice,

                };

                OrderDetail sameorderdetail = db.OrderDetails.Where(o => o.OrderDetailID == orderdetail.OrderDetailID).SingleOrDefault();

                if (sameorderdetail == null)
                {
                    throw new NullReferenceException(" there is no orderdetail for this current orders");
                }
                sameorderdetail.CalTotalOrderQuantity(order.OrderQuantity);
                sameorderdetail.CalTotalOrderPrice(order.OrderPrice*order.OrderQuantity);
                db.SaveChanges();

              Console.Write("this is order id ");
                Console.WriteLine(order.OrderID);
                Console.Write("this is order detail number ");
                Console.WriteLine(order.OrderDetailNumber); 

                Console.Write("this is customer id ");
                Console.WriteLine(order.CustomerNumber);
               
    
                db.Orders.Add(order);
           
                db.SaveChanges();
            }
           
            db.OrderDetails.Where(o => o.OrderDetailID == orderdetail.OrderDetailID).SingleOrDefault().CalSalesTaxPrice();
            db.OrderDetails.Where(o => o.OrderDetailID == orderdetail.OrderDetailID).SingleOrDefault().CalFinalPrice();
            db.SaveChanges();
        }
        
        public static bool PayOrder(TypeOfPayment paymentCompany, int cardNumber,  string cardholderName, string cardbillingAddress)
        {
            bool cardApproved = true;
            //to write code to check if payment went thru

            if (cardApproved)
            {

                var payment = new Payment()
                {



                    PaymentType = paymentCompany,
                    //  PaymentAmount = orderdetailfinalprice;



                };

            }

            return cardApproved;
        }

        public static OrderDetail GetOrderDetail(int OrderDetailNumber)
        {

            var orderdetail = db.OrderDetails.Where(o => o.OrderDetailID == OrderDetailNumber).SingleOrDefault();
            if (orderdetail == null)
            {
                throw new NullReferenceException("Order detail number does not exist");
            }
            return orderdetail;
        }

        public static IEnumerable<Order> GetOrders(int OrderDetailNumber) { 
            var orders = db.Orders.Where(o => o.OrderDetailNumber == OrderDetailNumber).ToList();
            if (orders == null)
            {
                throw new NullReferenceException( " Orders do not exist");
            }
            return orders;
        }

    }

   
}
