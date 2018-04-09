using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    class Delivery
    {
        #region
        private Order purchasedOrder { get; set; }
        private DateTime pendingdeliveryDate { get; set; }
        public bool delivered { get; set; }
        private DateTime actualdeliveryDate { get; set; }
        #endregion

        #region Methods
        public Order PurchasedOrder
        {
            get { return purchasedOrder; }
        }
        public DateTime PendingDeliveryDate
        {
            get { return pendingdeliveryDate; }

        }

        public bool Delivered
        {
            get { return delivered; }
        }

        public DateTime ActualDeliveryDate
        {
            get { return actualdeliveryDate; }
        }

        #endregion
    }
}
