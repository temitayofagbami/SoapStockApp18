using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    class Order
    {
        #region Properties
        private static int orderID { get; set; }
        private Customer orderCustomer { get; set; }
        private DateTime orderdateTime { get; set; }
        //i think this order class should have a property of collection  of class Product called OrderedProductList
        private int totalorderQuantity { get; set; }
        private decimal  totalorderPrice { get; set; }
        private double salestaxPrice { get; set; }
        private bool boolorderPaid { get; set; }
        #endregion

        #region Methods
        public int OrderID
        {
            get { return orderID; }
        }
        public Customer OrderCustomer
        {
            get { return orderCustomer; }
        }

        public DateTime OrderDateTime
        {
            get { return orderdateTime; }
        }

        public int TotalOrderQuantity
        {
            get { return totalorderQuantity; }   
        }
        public int CalTotalOrderQuantity
        {
            //not sure about this , but i will get values from OrderProductList
           get { return totalorderQuantity; }
        }

        public decimal TotalOrderPrice   
        {
            get { return totalorderPrice; }
        }
        public decimal CalTotalOrderPrice
        {
            //not sure about this, but i will get values from OrderProductList
            get { return totalorderPrice; }
        }
        
        public double CalSalesTaxPrice
        {
            //not sure if this is done right
           // set { salestaxPrice = (double)totalorderPrice * 0.10; } 
            get { return salestaxPrice = ((double)totalorderPrice * 0.10) ; }
        }

        public bool BoolOrderPaid
        {
            get { return boolorderPaid; }
        }
    }
}

