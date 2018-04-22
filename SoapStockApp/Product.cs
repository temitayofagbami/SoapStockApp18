using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{


    enum TypeOfProduct

    {

        Laundry_Detergent,

        Bar,

        Dish,

        Body_Wash,

    }


    class Product
    {
        private static int lastProductID = 0;
        #region Properties
        public int ProductID { get; private set; }
        public string  ProductName { get;  set; }
        public string ProductSupplierName { get; set; }
        public string ProductDescr { get;set; }
        public TypeOfProduct ProductType { get; set; }
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
        public void AddProductType(TypeOfProduct value)
        {
            ProductType = value;

        }
        public void SetProductPrice(decimal value)
        {
            ProductPrice = value;

        }
        public void IncrementProductQuantity(int value)
        {
            ProductQuantity += value;

        }
        #endregion
    }
}
