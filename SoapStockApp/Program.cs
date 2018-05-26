using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace SoapStockApp
{
    class Program
    {
        public static object MessageBox { get; private set; }

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
                Console.WriteLine("2. Customer: View Past Orders ");
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
                        IEnumerable<Product> products = new List<Product>();

                        Console.WriteLine(" Shopping ");
                        bool shopping = true;


                        Console.WriteLine("Browse whole invertory");

                        Console.WriteLine("-----------------------------------");
                        //Product products;
                        try
                        {
                            products = Inventory.GetAllProducts();
                            PrintProductList(products);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine(e.Message);
                            shopping = false;
                            break;
                        }

                        try { 
                        while (shopping)
                        {



                            Console.WriteLine("Make selection by Product Name");
                            var selectedProductName = Console.ReadLine();
                            Console.WriteLine($"How many units of  {selectedProductName} do you want: ");
                            var selectedQuantity = Convert.ToInt32(Console.ReadLine());

                            //wrapper
                            Product orderedproduct = Inventory.DecrementProductQuantity(selectedQuantity, selectedProductName);
                            //  orderedproduct.IncrementProductQuantity(selectedQuantity);
                            orderedproduct.ProductQuantity = selectedQuantity;
                            //need to get list products ordered
                            Console.WriteLine("Here is new  invertory numbers of selected product name");
                            products = Inventory.GetAllProductsByProductName(selectedProductName);
                            PrintProductList(products);
                            oproductlist.Add(orderedproduct);

                            Console.WriteLine(" Still Shopping, yes or done");
                            string shoppingstatus = Console.ReadLine().ToString();
                            if (shoppingstatus == "yes")
                                shopping = true;
                            else if (shoppingstatus == "done")
                                shopping = false;
                            else
                            {
                                Console.WriteLine(" incorrect input, Still Shopping, yes or done");
                                shoppingstatus = Console.ReadLine().ToString();
                                //needs to be fixed
                                shopping = true;
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

                            Store.CreateOrder(custName, custEmailAddress, custAddress, custPhoneNumber, oproductlist);
                            //if creation order is successful, pay for order

                            Console.WriteLine(" Please provide payment information for this order");
                            Console.WriteLine("***********************************");
                            Console.WriteLine(" Please provide  Credit card Company, Visa, MasterCard or American Express :");
                            var cardCompany = (TypeOfPayment)Enum.Parse(typeof(TypeOfPayment), Console.ReadLine());
                            Console.WriteLine(" Please provide  Card holder Number:");
                            int cardNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(" Please provide  Card holder Name:");
                            var cardName = Console.ReadLine();
                            Console.WriteLine(" Please provide Card Billing Address:");
                            var billingaddress = Console.ReadLine();
                            Store.PayOrder(cardCompany, cardNumber, cardName, billingaddress);
                        }

                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
                        catch (FormatException)
                        {

                            Console.WriteLine("  You have entered incorrect format type for card number please enter correct type");
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }


                        break;

                    case "2":

                        Console.WriteLine(" checking on Orders ");
                        bool repeat = true;
                        while (repeat)
                        {


                            Console.Write("Provide OrderDetail ID: ");
                            var orderdetailNumber = -1;

                            try
                            {
                                orderdetailNumber = Int32.Parse(Console.ReadLine());

                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("You have entered non-numeric characters");


                            }

                            try
                            {

                                var orderdetail = Store.GetOrderDetail(orderdetailNumber);
                                PrintOrderDetail(orderdetail);
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine($" Error: {e.Message}");
                            }
                            try
                            {

                                var orders = Store.GetOrders(orderdetailNumber);
                                PrintOrders(orders);
                            }
                            catch (NullReferenceException e)
                            {
                                Console.WriteLine($" Error: {e.Message}");
                            }




                            Console.WriteLine(" View another orderdetail ? Y/N");
                            try
                            {
                                string go = Console.ReadLine();
                                if (go == "Y" || go == "y")
                                {
                                    repeat = true;
                                }
                                else if (go == "N" || go == "n")
                                {
                                    repeat = false;
                                }
                                else
                                {
                                    Console.WriteLine(" Incorrect input.Please enter correct Y/N");
                                    repeat = true;
                                }
                            }

                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("You have entered non characters type");



                            }
                        }

                        break;

                    case "3":

                        try {

                            Console.Write("Provide Supplier Name: ");
                            var supplierName = Console.ReadLine();

                            Console.Write("Provide Product Name: ");
                            var productName = Console.ReadLine();

                            Console.Write("Provide Product Type: ");
                            var ptype = Enum.GetNames(typeof(TypeOfProduct));


                            for (var i = 0; i < ptype.Length; i++)
                            {
                                Console.WriteLine($"{i} : {ptype[i]}");
                            }

                            var productType = (TypeOfProduct)Enum.Parse(typeof(TypeOfProduct), Console.ReadLine());
                        //seperate into two try catches and have them try again
                        
                            Console.Write("Provide Product Price: ");
                            var productPrice = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Provide Product Quanitity to be added: ");
                            var initalQuantity = Convert.ToInt32(Console.ReadLine());
                        
                     
                   
                            var product = Inventory.CreateProduct(supplierName, productName, productType, productPrice, initalQuantity);

                            Console.WriteLine(" Product below was added to inventory");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine($"ProductID: {product.ProductID}, ProductName: {product.ProductName}, Product Price: {product.ProductPrice:C}, Product Quantity: {product.ProductQuantity:0}, By Supplier: {product.ProductSupplierName}");
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
                        catch ( ArgumentException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
                        catch (FormatException )
                        {
                            
                            Console.WriteLine("  You have entered incorrect format type for price or quantity. please enter correct type");
                        }
                        catch(NullReferenceException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
                        break;


                    case "4":

                        Console.Write("Provide Supplier Name: ");

                        try
                        {
                           var supplierName = Console.ReadLine();
                         
                            products = Inventory.GetAllProductsBySupplier(supplierName);

                            Console.WriteLine($" {supplierName}: List of Products in Inventory");
                            Console.WriteLine("--------------------------------------------------");

                            PrintProductList(products);
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
                        catch (FormatException)
                        {
                            
                            Console.WriteLine(" You have entered incorrect format for supplier name. Please try again");
                        }
                        catch(NullReferenceException e)
                        {
                            Console.WriteLine($" Error: {e.Message}");
                        }
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
        public static void PrintOrderDetail(OrderDetail printorderdetail)
        {

            Console.WriteLine($"OrderDetailD: {printorderdetail.OrderDetailID}");
            Console.WriteLine($"Total OrderQuantity :{printorderdetail.TotalOrderQuantity}");
            Console.WriteLine($"Total OrderPrice : {printorderdetail.TotalOrderPrice:C}");
            Console.WriteLine($" salestax: {printorderdetail.salestaxPrice:C}");
            Console.WriteLine($"Final Price: {printorderdetail.FinalPrice:C}");
            Console.WriteLine($"DeliveryDate: {printorderdetail.DeliveryTimeSelected.ToString("ggyyyy$dd - MMM(dddd)")}");
            Console.WriteLine($"OrderDetail Date: { printorderdetail.CreatedDate.ToString("YY:MM:dd:hh:mm:ss tt")}");

        }

        public static void PrintOrders(IEnumerable<Order> printorders)
        {
            foreach (var ord in printorders)

            {

                Console.WriteLine($"OrderDetailD: {ord.OrderDetailNumber}, OrderID: {ord.OrderID}, ProductNumber: {ord.ProductNumber}, Order Price: {ord.OrderPrice:C}, Order Quantity: {ord.OrderQuantity:0}, Order Date: { ord.CreatedDate.ToString("YY:MM:dd:hh:mm:ss tt")}");
            }
        }


    } 

}


        
