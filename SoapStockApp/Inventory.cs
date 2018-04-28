using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    static class Inventory
    {
        private static SoapStockModel db = new SoapStockModel();
        //private static List<Product> products = new List<Product>();

        
        public static Product CreateProduct(string productSuppliername,string productName,

             TypeOfProduct productType, decimal productPrice,

            int Quantity)

        {     

                var product = new Product
                {
                    ProductSupplierName = productSuppliername,
                    ProductName = productName,
                    ProductType = productType,

                };


                product.SetProductPrice(productPrice);

            if (Quantity > 0)

            {
                product.IncrementProductQuantity(Quantity);
            }


            db.Products.Add(product);
            db.SaveChanges();
           

            return product;

        }



        public static IEnumerable<Product> GetAllProductsBySupplier(string productSupplierName)

        {

            // return products.Where(p => p.ProductSupplierName== productSupplierName);
            return db.Products.Where(p => p.ProductSupplierName == productSupplierName);
        }

        public static IEnumerable<Product> GetAllProductsByProductName(string productName)

        {

            // return products.Where(p => p.ProductName == productName);
            return db.Products.Where(p => p.ProductName == productName);

        }
        public static IEnumerable<Product> GetAllProducts()

        {

            return db.Products.Where(p => p.ProductQuantity > 0);

        }
        public static bool ProductExistInInventory(string productName)
        {
            bool boolExist = false;
               db.Products.Where(p => p.ProductName == productName).ToList().ForEach(q=>boolExist=true);
           // db.Products.Where(p => p.ProductName == productName).SingleOrDefault();
            return boolExist;

        }
        public static Product DecreaseProductQuantity(int selectedQuantity, string productName)
        {
           var orderedproduct = db.Products.Where(p => p.ProductName == productName).SingleOrDefault();
            orderedproduct.ProductQuantity = selectedQuantity;
           // db.Products.Where(p =>p.ProductName==productName).ToList().ForEach(q=>q.DecrementProductQuantity(selectedQuantity));
            db.Products.Where(p => p.ProductName == productName).SingleOrDefault().DecrementProductQuantity(selectedQuantity);
            db.SaveChanges();
            return orderedproduct;
        }
        public static void IncreaseProductQuantity(int selectedQuantity, string productName)
        {
            db.Products.Where(p => p.ProductName == productName).SingleOrDefault().IncrementProductQuantity(selectedQuantity);
            db.SaveChanges();
        }

    }
}

