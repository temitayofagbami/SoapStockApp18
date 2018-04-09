using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    class Customer
    {
        #region Properties
        private int CustomerID { get; set; }
        private string CustomerName { get; set; }
        private string CustomerEmail { get; set; }
        private string CustomerAddr { get; set; }
        private string CustomerPhone { get; set; }
        #endregion


        #region Methods
        public int getCustomerID
        {
            get { return CustomerID; }
        }
        public string getCustomerName
        {
            get { return CustomerName; }
            set { CustomerName = value; }
        }
        public string getCustomerEmail
        {
            get { return CustomerEmail; }
            set { CustomerEmail = value; }
        }
        public string getCustomerAddr
        {
            get { return CustomerAddr; }
            set { CustomerAddr = value; }
        }
        public string getCustomerPhone
        {
            get { return CustomerPhone; }
            set { CustomerPhone = value; }
        }
        #endregion
    }
}
