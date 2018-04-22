using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    static class Inventory
    {

        private static List<Product> products = new List<Product>();

        
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

            products.Add(product);

            return product;

        }



        public static IEnumerable<Product> GetAllProducts(string productSupplierName)

        {
            
            return products.Where(p => p.ProductSupplierName== productSupplierName);

        }

    }
}

