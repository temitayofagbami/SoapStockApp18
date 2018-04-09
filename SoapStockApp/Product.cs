using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    
    class Product
    {
        #region Properties
        private int ProductID { get; set; }
        private string  ProductName { get; set; }
        private string ProductDescr { get; set; }
        private string ProductType { get; set; }
        private decimal ProductPrice { get; set; }
        private int ProductQuantity { get; set; }
        #endregion

        #region Methods
        public int getProductID
        {
            get { return ProductID; }
        }
        public string   getProductName
        {
           get { return ProductName; }
        }
        public string getProductDescr
        {
            get { return ProductDescr; }
        }
        public string getProductType
        {
            get { return ProductType; }
        }
        public decimal getProductPrice
        {
            get { return ProductPrice; }
        }
        public int getProductQuantity
        {
            get { return ProductQuantity; }
            set { ProductQuantity = value; }
        }

        #endregion
    }
}
