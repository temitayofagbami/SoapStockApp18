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
            if (string.IsNullOrEmpty(productSuppliername))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
            
          //what do we do for others
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
                else
                {
                    throw new ArgumentException("Quantity", " Product quantity is not enough to be added in inventory.Please choose another quantity");
                }
               
                db.Products.Add(product);
                db.SaveChanges();

            }
            else
            {
                
                    product = GetProductBySupplier(productSuppliername, productName);
                if (Quantity > 0)

                {
                    IncreaseProductQuantity(Quantity, productName);
                }
                else
                {
                    throw new ArgumentException("Quantity", " Product quantity is not enough to be added in inventory");
                }
            }
            return product;

        }



        public static IEnumerable<Product> GetAllProductsBySupplier(string productSupplierName)

        {

            if (string.IsNullOrEmpty(productSupplierName))
            {
                throw new ArgumentNullException(" the SupplierName was not provided");
            }
           var products = db.Products.Where(p => p.ProductSupplierName == productSupplierName);
            if (products.ToArray().Length == 0)
            {
                throw new NullReferenceException(" Supplier does not have products in inventory");
            }
            return products;
           
        }
        public static Product GetProductBySupplier(string productSupplierName, string productName)

        {
            if (string.IsNullOrEmpty(productSupplierName))
            {
                throw new ArgumentNullException(" the SupplierName was not provided");
            }
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
            var product = db.Products.Where(p => p.ProductSupplierName == productSupplierName).ToList().Where(q => q.ProductName == productName).SingleOrDefault();
            if (product== null)
            {
                throw new NullReferenceException(" Supplier does not have this specific product in inventory");
            }

            return product;

        }

        public static IEnumerable<Product> GetAllProductsByProductName(string productName)

        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
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
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
            bool boolExist = false;
            db.Products.Where(p => p.ProductName == productName).ToList().ForEach(q=>boolExist=true);
            return boolExist;

        }
        public static Product DecrementProductQuantity(int selectedQuantity, string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
            //if quantity == null or less than 0, throw exception

           
            Product oproduct = db.Products.Where(p => p.ProductName == productName).SingleOrDefault();

            if (oproduct == null)
            {
                throw new NullReferenceException(" the product is not in inventory");
            }
            if(oproduct.ProductQuantity == 0)
            {
                throw new ArgumentException(" the product is out of stock. Waiting to be restocked");
            }
        
            oproduct.DecrementProductQuantity(selectedQuantity);
            db.SaveChanges();
          //  Product oproduct = db.Products.Where(p => p.ProductName == productName).SingleOrDefault();
            return oproduct;
        }
        public static void IncreaseProductQuantity(int selectedQuantity, string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(" the productName was not provided");
            }
            //if quantity == null or less than 0, throw exception

            db.Products.Where(p => p.ProductName == productName).SingleOrDefault().IncrementProductQuantity(selectedQuantity);
            db.SaveChanges();
        }

    }
}

