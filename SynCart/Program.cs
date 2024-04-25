using System;
using System.Collections.Generic;
namespace SynCart;
class Program
{
    public static void Main(string[] args)
    {
        List<ProductDetails> productDetailsList = new List<ProductDetails>();
        List<CustomerDetails> customerDetailsList = new List<CustomerDetails>();
        List<OrderDetails> orderDetailsList = new List<OrderDetails>();

        //Default values
        ProductDetails productDetails1 = new ProductDetails("Mobile (Samsung)", 10000, 10, 3);
        ProductDetails productDetails2 = new ProductDetails("Tablet (Lenovo)", 15000, 5, 2);
        ProductDetails productDetails3 = new ProductDetails("Camara (Sony)", 20000, 3, 4);
        ProductDetails productDetails4 = new ProductDetails("iPhone", 50000, 5, 6);
        ProductDetails productDetails5 = new ProductDetails("Laptop (Lenovo I3)", 40000, 3, 3);
        ProductDetails productDetails6 = new ProductDetails("HeadPhone (Boat)", 1000, 5, 2);
        ProductDetails productDetails7 = new ProductDetails("Speakers (Boat)", 500, 4, 2);

        productDetailsList.Add(productDetails1);
        productDetailsList.Add(productDetails2);
        productDetailsList.Add(productDetails3);
        productDetailsList.Add(productDetails4);
        productDetailsList.Add(productDetails5);
        productDetailsList.Add(productDetails6);
        productDetailsList.Add(productDetails7);

        CustomerDetails customerDetails1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
        CustomerDetails customerDetails2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");

        customerDetailsList.Add(customerDetails1);
        customerDetailsList.Add(customerDetails2);

        OrderDetails orderDetails1 = new OrderDetails("CID1001", "PID101", 20000, DateTime.Now, 2, OrderStatus.Ordered);
        OrderDetails orderDetails2 = new OrderDetails("CID1002", "PID103", 40000, DateTime.Now, 2, OrderStatus.Ordered);

        orderDetailsList.Add(orderDetails1);
        orderDetailsList.Add(orderDetails2);
        //end of default values

        Console.WriteLine("Welcome to SynCart");
        int option;
        do
        {

            Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit");
            Console.Write("select any option :");
            bool isoptValid = int.TryParse(Console.ReadLine(), out option);
            while (!isoptValid)
            {
                Console.WriteLine("Enter valid number as input");
                Console.Write("select any option :");
                isoptValid = int.TryParse(Console.ReadLine(), out option);
            }
            switch (option)
            {
                case 1:
                    {
                        //Registration

                        Console.Write("Enter Name: ");
                        string customerName = Console.ReadLine();

                        Console.Write("Enter City: ");
                        string city = Console.ReadLine();

                        long phoneNumber;
                        Console.Write("Enter Phone Number: ");
                        bool isphoneNumberValid = long.TryParse(Console.ReadLine(), null, out phoneNumber);
                        while (!isphoneNumberValid || !(phoneNumber > 0))
                        {
                            Console.WriteLine("Enter valid Number");
                            Console.Write("Enter Phone Number: ");
                            isphoneNumberValid = long.TryParse(Console.ReadLine(), null, out phoneNumber);

                        }

                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        double walletBalance;
                        Console.Write("Enter amount to deposit in wallet: ");
                        bool iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);
                        while (!iswalletBalanceValid || !(walletBalance > 0))
                        {
                            Console.WriteLine("Enter valid Number");
                            Console.Write("Enter amount to deposit in wallet: ");
                            iswalletBalanceValid = double.TryParse(Console.ReadLine(), null, out walletBalance);

                        }

                        CustomerDetails customerDetails = new CustomerDetails(customerName, city, phoneNumber, walletBalance, email);

                        customerDetailsList.Add(customerDetails);

                        Console.WriteLine($"Customer Registered Successfully and StudentID is {customerDetails.CustomerId}");

                        break;
                    }
                case 2:
                    {
                        //Login

                        Console.Write("Enter Customer Id: ");
                        string usrId = Console.ReadLine();
                        bool flag = true;
                        foreach (CustomerDetails customer in customerDetailsList)
                        {
                            if (customer.CustomerId == usrId)
                            {
                                flag = false;
                                int choice = 0;
                                do
                                {
                                    Console.WriteLine("a. Purchase\nb. Order History\nc. Cancel order\nd. Wallet Balance\ne. Wallet Recharge\nf. exit");
                                    Console.Write("select any option :");

                                    char option1;
                                    bool isopt1Valid = char.TryParse(Console.ReadLine(), out option1);
                                    while (!isopt1Valid)
                                    {
                                        Console.WriteLine("Enter valid character as input");
                                        Console.Write("select any option :");
                                        isopt1Valid = char.TryParse(Console.ReadLine(), out option1);
                                    }

                                    switch (option1)
                                    {
                                        case 'a':
                                            {
                                                //Purchase
                                                foreach (ProductDetails product in productDetailsList)
                                                {
                                                    Console.WriteLine($"| {product.ProductId} | {product.ProductName} | {product.Stock} | {product.Price} | {product.ShippingDuration}");
                                                }
                                                Console.Write($"Enter product Id to purchase : ");
                                                string productId = Console.ReadLine();
                                                bool isProduct = true;
                                                foreach (ProductDetails productDetails in productDetailsList)
                                                {
                                                    if (productDetails.ProductId == productId)
                                                    {
                                                        isProduct = false;
                                                        System.Console.Write("Enter the quantity you want to purchase: ");
                                                        int count = int.Parse(Console.ReadLine());
                                                        if (count > productDetails.Stock)
                                                        {
                                                            Console.WriteLine($"Required count not available. Current availability is {productDetails.Stock}");
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            //Total Amount = (required count * price per quantity) + Delivery charge
                                                            double total = count*productDetails.Price+50;
                                                            if(customer.WalletBalance<total)
                                                            {
                                                                Console.WriteLine("Insufficient Wallet Balance. Please recharge your wallet and do purchase again.");
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                customer.WalletBalance-=total;
                                                                productDetails.Stock-=count;

                                                                OrderDetails orderDetails = new OrderDetails(customer.CustomerId,productDetails.ProductId,total,DateTime.Now,count,OrderStatus.Ordered);
                                                                orderDetailsList.Add(orderDetails);
                                                                Console.WriteLine($"Order Placed Successfully. Order ID: {orderDetails.OrderId}");
                                                                Console.WriteLine($"Your order will be delivered on {orderDetails.PurchaseDate.AddDays(productDetails.ShippingDuration):dd/MM/yyyy}.");
                                                            }
                                                        }
                                                        break;
                                                    }
                                                }
                                                if (isProduct)
                                                {
                                                    Console.WriteLine("Invalid Product Id.");
                                                }
                                                break;
                                            }
                                        case 'b':
                                            {
                                                //Order History
                                                Console.WriteLine("Orders History");
                                                foreach (OrderDetails orderDetails in orderDetailsList)
                                                {
                                                    if (orderDetails.CustomerId == customer.CustomerId)
                                                    {
                                                        Console.WriteLine($"| {orderDetails.OrderId} | {orderDetails.CustomerId} | {orderDetails.ProductId} | {orderDetails.TotalPrice} | {orderDetails.PurchaseDate:dd/MM/yyyy} | {orderDetails.Quantity} | {orderDetails.orderStatus} |");
                                                    }
                                                }
                                                break;
                                            }
                                        case 'c':
                                            {
                                                //Cancel order
                                                foreach (OrderDetails orderDetails in orderDetailsList)
                                                {
                                                    if (orderDetails.CustomerId == customer.CustomerId)
                                                    {
                                                        Console.WriteLine($"| {orderDetails.OrderId} | {orderDetails.CustomerId} | {orderDetails.ProductId} | {orderDetails.TotalPrice} | {orderDetails.PurchaseDate:dd/MM/yyyy} | {orderDetails.Quantity} | {orderDetails.orderStatus} |");
                                                    }
                                                }
                                                System.Console.Write("Enter the order Id to cancel: ");
                                                string orderId = Console.ReadLine();
                                                bool isOrder = true;
                                                foreach (OrderDetails orderDetails in orderDetailsList)
                                                {
                                                    if (orderDetails.OrderId == orderId)
                                                    {
                                                        isOrder=false;
                                                        foreach(ProductDetails productDetails in productDetailsList)
                                                        {
                                                            if(productDetails.ProductId==orderDetails.ProductId)
                                                            {
                                                                productDetails.Stock+=orderDetails.Quantity;
                                                                customer.WalletBalance+=orderDetails.TotalPrice;
                                                                orderDetails.orderStatus=OrderStatus.Cancelled;
                                                                System.Console.WriteLine($"Order: {orderDetails.OrderId} cancelled sucessfully.");
                                                                break;
                                                            }
                                                        }
                                                        break;
                                                    }
                                                }
                                                if(isOrder)
                                                {
                                                    System.Console.WriteLine("Invalid Order Id");
                                                }
                                                break;
                                            }
                                        case 'd':
                                            {
                                                //Wallet Balance
                                                Console.WriteLine($"Wallet balance: {customer.WalletBalance}");
                                                break;
                                            }
                                        case 'e':
                                            {
                                                //Wallet Recharge
                                                double amount;
                                                Console.Write("Enter amount to deposit in wallet: ");
                                                bool isamountValid = double.TryParse(Console.ReadLine(), null, out amount);
                                                while (!isamountValid || !(amount > 0))
                                                {
                                                    Console.WriteLine("Enter valid Number");
                                                    Console.Write("Enter amount to deposit in wallet: ");
                                                    isamountValid = double.TryParse(Console.ReadLine(), null, out amount);

                                                }
                                                Console.WriteLine($"Wallet balance: {customer.WalletRecharge(amount)}");
                                                break;
                                            }
                                        case 'f':
                                            {
                                                //Exit
                                                choice = 1;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Provide valid input a-f");
                                                break;
                                            }
                                    }

                                } while (choice != 1);
                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine("Invalid Customer ID");
                        }
                        break;
                    }
                case 3:
                    {
                        //Exit
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Provide valid input 1-3");
                        break;
                    }
            }
        } while (option != 3);
    }
}