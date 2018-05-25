using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{


    public enum TypeOfPayment

    {
        [Display(Name = "Visa")]

        Visa,

        [Display(Name = "MasterCard")]
        MasterCard,
        [Display(Name = "AmericanExpress")]
        AmericanExpress,
        [Display(Name = "PayPal")]
        PayPal,

    }

    class Payment
    {
        private static int lastPaymentID = 0;

        #region Properties
        [Key]
        public int PaymentID { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public TypeOfPayment PaymentType { get; set; }
        public decimal PaymentAmount { get; set; }
       public bool BoolOrderPaid { get; set; }

        #endregion




        #region Constructor
        public Payment()
        {
            PaymentID = ++lastPaymentID;
    
            PaymentDate = DateTime.UtcNow;
            
            PaymentAmount = 0;
           


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
