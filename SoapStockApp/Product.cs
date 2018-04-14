using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    
    class Product
    {
        private static int lastProductID = 0;
        #region Properties
        public int ProductID { get; private set; }
        public string  ProductName { get;  set; }
        public string ProductDescr { get;private set; }
        public string ProductType { get; private set; }
        public decimal ProductPrice { get; private set; }
        public int ProductQuantity { get; set; }
        #endregion


        #region Constructor
        public Product()
        {
            ProductID = ++lastProductID;

        }
        #endregion
        #region Methods
        //these will be called by store owner, not customer
        public void AddProductName(string value)
    {
        ProductName = value;

    }
        public void AddProductDescr(string value)
        {
            ProductDescr = value;

        }
        public void AddProductType(string value)
        {
            ProductType = value;

        }
        public void AddProductPrice(decimal value)
        {
            ProductPrice = value;

        }
        #endregion
    }
}
