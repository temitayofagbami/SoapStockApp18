using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    
    class Item
    {
        #region Properties
        public int ItemID { get; set; }
        public string  ItemName { get; set; }
        public string ItemType { get; set; }
        public decimal ItemCost { get; set; }
    }
}
