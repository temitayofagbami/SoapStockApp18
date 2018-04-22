using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapStockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("**Welcome to the SoapStock!**");
            Console.WriteLine("-----------------------------------");


            while (true)

            {
                Console.WriteLine("Please select an option from below: ");

                Console.WriteLine("0. Quit");
                Console.WriteLine("1. Customer: Shop for Soaps ");
                Console.WriteLine("2. Customer: checkout Orders ");
                Console.WriteLine("3. Supplier:Adding Products in inventory ");
                Console.WriteLine("4. Supplier:View Products in inventory ");

                var option = Console.ReadLine();

                switch (option)

                {
                    case "0":

                        Console.WriteLine("Thank you for visiting SoapStock!");
                        return;

                    case "1":

                        Console.WriteLine(" Shopping ");
                        break;

                    case "2":

                        Console.WriteLine(" checking on Orders ");
                        break;

                    case "3":

                        Console.Write("Provide Supplier Name: ");
                        var supplierName = Console.ReadLine();

                        Console.Write("Provide Product Name: ");
                        var productName = Console.ReadLine();

                        Console.Write("Provide Product Type: ");
                        var productType = (TypeOfProduct)Enum.Parse(typeof(TypeOfProduct), Console.ReadLine());

                        Console.Write("Provide Product Price: ");
                        var productPrice = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Provide Product Quanitity to be added: ");
                        var initalQuantity = Convert.ToInt32(Console.ReadLine());

                        var product = Inventory.CreateProduct(supplierName, productName, productType, productPrice, initalQuantity);

                        Console.WriteLine(" Product below was added to inventory");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}, Product Price: {product.ProductPrice:C}, Product Quantity: {product.ProductQuantity:C}, by By Supplier: {product.ProductSupplierName}");

                        break;


                    case "4":

                        Console.Write("Provide Supplier Name: ");

                        supplierName = Console.ReadLine();

                        var products = Inventory.GetAllProducts(supplierName);
                        Console.WriteLine($" {supplierName}: List of Products in Inventory");
                        Console.WriteLine("--------------------------------------------------");

                        foreach (var prdt in products)

                        {

                            Console.WriteLine($"ProductID: {prdt.ProductID}, ProductName: {prdt.ProductName}, Product Price: {prdt.ProductPrice:C}");

                        }

                        break;

                }

            }

        }

    } 

}


        
