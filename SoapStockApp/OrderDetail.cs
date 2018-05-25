using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    public class OrderDetail
    {
        private static int lastOrderDetailID = 0;
        //private static int SaleTaxPercentage = 15 / 100;

        #region Properties
        [Key]
        public int OrderDetailID { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public int TotalOrderQuantity { get; private set; }
        public decimal TotalOrderPrice { get; private set; }
        public decimal salestaxPrice { get; private set; }
        public decimal FinalPrice { get; private set; }
        public DateTime DeliveryTimeSelected { get; set; }
        public bool BoolOrderPaid { get; private set; }

    



        #endregion




        #region Constructor
        public OrderDetail()
        {
            OrderDetailID = ++lastOrderDetailID;
            TotalOrderQuantity = 0;
            TotalOrderPrice = 0;
            salestaxPrice = 0;
            FinalPrice = 0;
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

        public void CalTotalOrderQuantity(int value)
        {
            TotalOrderQuantity += value;

        }

        public void CalTotalOrderPrice( decimal value)
        {
             TotalOrderPrice += value;

        }


        public void CalSalesTaxPrice()
        {
            salestaxPrice = (decimal)((10/100) * TotalOrderPrice);

        }
        public void CalFinalPrice()
        {
            FinalPrice = (decimal)(salestaxPrice + TotalOrderPrice);

        }

      
        #endregion

    }
}
