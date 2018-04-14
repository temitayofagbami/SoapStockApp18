using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    
    class Delivery
    {
        private static int standardDeliveryTime = 2;

        #region
        public Order PurchasedOrder { get; private set; }
        public DateTime PendingDeliveryDate { get; private set; }
        public bool Delivered { get; private set; }
        public DateTime ActualDeliveryDate { get; private set; }
        #endregion

        #region Constructor
        public Delivery()
        {

            ActualDeliveryDate = new DateTime(0, 0, 0);
            TimeSpan time = new TimeSpan(standardDeliveryTime, 0, 0, 0);
            PendingDeliveryDate = PurchasedOrder.CreatedDate.Add(time);
            Delivered = false;
        }
        #endregion

        #region Methods
        public void CalPendingDeliveryDateDate(int value)
        {
            if (value <= 0)
            {
                Console.WriteLine(" Sorry, we do not have same day delivery or next day delivery. The least delivery time is 2 days");
            }

            else{
                TimeSpan time = new TimeSpan(value, 0, 0, 0);
                PendingDeliveryDate = PurchasedOrder.CreatedDate.Add(time);
            }
        }

        public void DeliveryDone(bool value)
        {
            Delivered = value;
            ActualDeliveryDate = DateTime.UtcNow;

        }

        #endregion
    }
}
