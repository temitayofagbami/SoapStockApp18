using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    public class Customer
    {
        private static int lastCustomerID = 0;
        #region Properties
        public int CustomerID { get; private set; }
        [Required]
        [StringLength(30, ErrorMessage = "Customer Name cannot be more than 30 characters in length")]
        public string CustomerName { get;  set; }
        [Required]
        [StringLength(50, ErrorMessage = "Customer Email Address cannot be more than 50 characters in length")]
        public string CustomerEmail { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Customer Address cannot be more than 100 characters in length")]
        public string CustomerAddr { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Customer Phone cannot be more than 30 characters in length")]
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
