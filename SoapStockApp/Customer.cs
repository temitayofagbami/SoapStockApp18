using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    class Customer
    {
        private static int lastCustomerID = 0;
        #region Properties
        public int CustomerID { get; private set; }
        public string CustomerName { get;  set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddr { get; set; }
        public string CustomerPhone { get; set; }
        #endregion


        #region Constructor
        public Customer()
        {
            CustomerID = ++lastCustomerID;
           
        }
        #endregion

        #region Methods

        #endregion
    }
}
