using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    static class Inventory
    {
        /// <summary>
        /// 
        /// </summary>
        /// 
        private static SoapStockModel db = new SoapStockModel();
        //private static List<Product> products = new List<Product>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productSuppliername"></param>
        /// <param name="productName"></param>
        /// <param name="productType"></param>
        /// <param name="productPrice"></param>
        /// <param name="Quantity"></param>
        /// <returns></returns>

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

            if (!ProductExistInInventory(productName))
            {
               

                product.SetProductPrice(productPrice);

                if (Quantity > 0)

                {
                    product.IncrementProductQuantity(Quantity);
                }
               
                db.Products.Add(product);
                db.SaveChanges();

            }
            else
            {
                 product = GetProductBySupplier(productSuppliername, productName);
                 IncreaseProductQuantity(Quantity, productName);
            }
            return product;

        }



        public static IEnumerable<Product> GetAllProductsBySupplier(string productSupplierName)

        {
           var products = db.Products.Where(p => p.ProductSupplierName == productSupplierName);
            if (products.ToArray().Length == 0)
            {
                throw new NullReferenceException(" Supplier does not have products in inventory");
            }
            return products;
           
        }
        public static Product GetProductBySupplier(string productSupplierName, string productName)

        {
            var product = db.Products.Where(p => p.ProductSupplierName == productSupplierName).ToList().Where(q => q.ProductName == productName).SingleOrDefault();
            if (product== null)
            {
                throw new NullReferenceException(" Supplier does not have this specific product in inventory");
            }

            return product;

        }

        public static IEnumerable<Product> GetAllProductsByProductName(string productName)

        {
           var products = db.Products.Where(p => p.ProductName == productName);
            if (products.ToArray().Length == 0)
            {
                throw new NullReferenceException(" this product is not in inventory");
            }
            return products;

        }
        public static IEnumerable<Product> GetAllProducts()

        {
            var products = db.Products.Where(p => p.ProductQuantity > 0);
            if (products.ToArray().Length ==0)
            {
                throw new NullReferenceException(" Inventory is empty");
            }
            return products;

         

        }
        public static bool ProductExistInInventory(string productName)
        {
            bool boolExist = false;
            db.Products.Where(p => p.ProductName == productName).ToList().ForEach(q=>boolExist=true);
            return boolExist;

        }
        public static Product DecrementProductQuantity(int selectedQuantity, string productName)
        {

          
            db.Products.Where(p => p.ProductName == productName).SingleOrDefault().DecrementProductQuantity(selectedQuantity);
            db.SaveChanges();
            Product oproduct = db.Products.Where(p => p.ProductName == productName).SingleOrDefault();
            return oproduct;
        }
        public static void IncreaseProductQuantity(int selectedQuantity, string productName)
        {
            db.Products.Where(p => p.ProductName == productName).SingleOrDefault().IncrementProductQuantity(selectedQuantity);
            db.SaveChanges();
        }

    }
}

