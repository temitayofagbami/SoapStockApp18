using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    class Order
    {
        private static int lastOrderID = 0;
        private static int SaleTaxPercentage = 15/100;

        #region Properties
        public int OrderID { get; private set; }
       // public Customer OrderCustomer { get; set; }
        public DateTime CreatedDate { get; private set; }
        //i think this order class should have a property of collection  of class Product called OrderedProductList
        public int TotalOrderQuantity { get; private set; }
        public double  TotalOrderPrice { get; private set; }
        public double salestaxPrice { get; private set; }
        public double FinalPrice { get; private set; }
        public int DeliveryTimeSelected { get;  set; }
        public  bool BoolOrderPaid { get; private set; }
        #endregion




        #region Constructor
        public Order()
        {
            OrderID = ++lastOrderID;
            TotalOrderQuantity = 0;
            TotalOrderPrice = 0;
            FinalPrice = 0;
            CreatedDate = DateTime.UtcNow;
            BoolOrderPaid = false;
        }
        #endregion

        #region Methods
        public void OrderPaid(bool value)
        {
            BoolOrderPaid = value;

        }

        public void CalTotalOrderQuantity()
        {
            // TotalOrderQuantity = summation of OrderedProductlist.ProductQuantity;

        }

        public void CalTotalOrderPrice()
        {
           // TotalOrderPrice = summation of OrderedProductlist.ProductPrice;

        }


        public void CalSalesTaxPrice()
        {
          salestaxPrice =(double) (SaleTaxPercentage * TotalOrderPrice);

        }
        public void CalFinalPrice()
        {
            FinalPrice = (double) (salestaxPrice + TotalOrderPrice);

        }

        #endregion

    }
}