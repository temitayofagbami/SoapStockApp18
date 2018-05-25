using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    public class Order
    {
        private static int lastOrderID = 0;
        // private static int SaleTaxPercentage = 15/100;

        #region Properties
        [Key]
        public int OrderID { get; private set; }
        // public Customer OrderCustomer { get; set; }
        public DateTime CreatedDate { get; private set; }
        //i think this order class should have a property of collection  of class Product called OrderedProductList
        public int OrderQuantity { get; set; }
        public decimal OrderPrice { get; set; }
        // public double salestaxPrice { get; private set; }
        //  public double FinalPrice { get; private set; }
        public DateTime DeliveryTimeSelected { get; set; }
        public bool BoolOrderPaid { get; private set; }

        [ForeignKey("Product")]
        public int ProductNumber { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerNumber { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("OrderDetail")]
        public int OrderDetailNumber { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }



        #endregion




        #region Constructor
        public Order()
        {
            OrderID = ++lastOrderID;
            OrderQuantity = 0;
            OrderPrice = 0;
            //salestaxPrice = 0;
            //FinalPrice = 0;
            CreatedDate = DateTime.UtcNow;
            DeliveryTimeSelected = CreatedDate.AddDays(2.0);
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

       
        #endregion

    }
}