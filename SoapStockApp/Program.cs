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
                        List<Product> oproductlist = new List<Product>();
                        // IEnumerable<Product> products = new List<Product>();
                       // var products;
                        Console.WriteLine(" Shopping ");
                        bool shopping = true;
                        
                       
                            Console.WriteLine("Browse whole invertory");
                          var  products = Inventory.GetAllProducts();
                            Console.WriteLine("-----------------------------------");

                            PrintProductList(products);
                        while (shopping)
                        {
                            Console.WriteLine("Make selection by Product Name");
                            var selectedProductName = Console.ReadLine();
                           // var products = Inventory.GetAllProductsByProductName(selectedProductName);
                            Console.WriteLine($"How many units of  {selectedProductName} do you want: ");
                            var selectedQuantity = Convert.ToInt32(Console.ReadLine());

                            //wrapper
                            Inventory.DecrementProductQuantity(selectedQuantity, selectedProductName);

                            Console.WriteLine("Here is new  invertory numbers");
                            products = Inventory.GetAllProductsByProductName(selectedProductName);
                            PrintProductList(products);
                           // oproductlist.Add(orderedproduct);

                            Console.WriteLine(" Still Shopping, yes or done");
                            string shoppingstatus = Console.ReadLine().ToString();
                            if (shoppingstatus == "yes")
                                shopping = true;
                            else if(shoppingstatus== "done")
                                shopping = false;
                            else
                            {
                                Console.WriteLine(" incorrect input, Still Shopping, yes or done");
                                shoppingstatus = Console.ReadLine().ToString();
                                //needs to be fixed
                            }

                        }


                        //once done shopping, create order and customer in store
                        Console.WriteLine(" Creating order for this customer");
                        Console.WriteLine("***********************************");
                        Console.WriteLine(" Please provide  Name:");
                        var custName = Console.ReadLine();
                        Console.WriteLine(" Please provide Email address:");
                        var custEmailAddress = Console.ReadLine();
                        Console.WriteLine(" Please provide Address:");
                        var custAddress = Console.ReadLine();
                        Console.WriteLine(" Please provide Phone Number:");
                        var custPhoneNumber = Console.ReadLine();

                        Store.CreateOrder(custName, custEmailAddress, custAddress, custPhoneNumber,  oproductlist);

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

                        if (!Inventory.ProductExistInInventory(productName))
                        {
                            var product = Inventory.CreateProduct(supplierName, productName, productType, productPrice, initalQuantity);

                            Console.WriteLine(" Product below was added to inventory");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}, Product Price: {product.ProductPrice:C}, Product Quantity: {product.ProductQuantity:0}, By Supplier: {product.ProductSupplierName}");
                        }
                        else
                        {
                            //already in inventory and we just have to update quantity
                            Inventory.IncreaseProductQuantity(initalQuantity, productName);
                        }
                        break;


                    case "4":

                        Console.Write("Provide Supplier Name: ");

                        supplierName = Console.ReadLine();

                      products = Inventory.GetAllProductsBySupplier(supplierName);
                        Console.WriteLine($" {supplierName}: List of Products in Inventory");
                        Console.WriteLine("--------------------------------------------------");

                        PrintProductList(products);
                        break;

                }

            }

        }

        //print products returned
        public static void PrintProductList(IEnumerable<Product> printproducts) {

            foreach (var prdt in printproducts)

            {

                Console.WriteLine($"ProductID: {prdt.ProductID}, ProductName: {prdt.ProductName}, Product Price: {prdt.ProductPrice:C}, Product Quantity: {prdt.ProductQuantity:0}");

            }

        }

    } 

}


        
