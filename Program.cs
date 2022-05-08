using System;
using System.Collections.Generic;

namespace ShoppingMallDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================== Welcome ====================");
            string inputstatus = "";
        programStart:
            Console.WriteLine("1: Add New Product");
            Console.WriteLine("2: Show Product List");
            Console.WriteLine("3: Update the existing Product");
            Console.WriteLine("4: Delete the existing Product");
            Console.WriteLine("5: Exit");
            Console.WriteLine("Select the Operation(1,2,3,4,5) : ");
            UserService userService = new UserService();
            Product product = new Product();
            inputstatus = Console.ReadLine();
            bool IsContinute = true;
            while (IsContinute)
            {
                switch (inputstatus)
                {
                    case "1":
                        {
                            Console.Write("Enter Product Id : ");
                            product.Id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Product Name : ");
                            product.Name = (Console.ReadLine());
                            Console.Write("Enter Product Price : ");
                            product.Price = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter Product Category : ");
                            product.Category = Console.ReadLine();
                            userService.SaveUser(product);
                            bool result = DecisionForNextTime();
                            if (result)
                                goto programStart;
                            else IsContinute = false;
                        }
                        break;
                    case "2":
                        {
                            List<Product> info = userService.GetInfo();
                            Console.WriteLine("Product Information Here ");
                            Console.WriteLine("ProductId\tName\t\tPrice\t\tCategory");
                            foreach (Product p in info)
                            {
                                Console.WriteLine("/t " +p.Id + "\t\t" + p.Name + "\t\t" + p.Price + "\t\t" + p.Category);
                            }
                            bool result = DecisionForNextTime();
                            if (result)
                                goto programStart;
                            else
                                IsContinute = false;
                        }
                        break;
                   
                    case "3":
                        {
                            Console.WriteLine("Choice product to update");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Name : ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Price : ");
                            decimal price =Convert.ToDecimal( Console.ReadLine());
                            Console.Write("Enter Category : ");
                            string category = Console.ReadLine();

                            Product infoer = new Product();
                            infoer.Id = id;//7
                            infoer.Name = name;//Aung zaw
                            infoer.Price = price;
                            infoer.Category = category;
                            userService.UpdateUserById(infoer);
                            goto case "2";
                        }
                    case "4":
                        {
                            Console.WriteLine("Please type product id to delete");
                            int id = int.Parse(Console.ReadLine());
                            userService.DeleteByUserId(id);

                            goto case "2";
                        }
                    case "5":
                        {


                            goto exitKey;


                        }
                        
                        

                    default:
                        Console.WriteLine("(we Only accept 1,2,3,4 Numbers)");
                        goto programStart;
                }
            }
        exitKey:
            Console.WriteLine("GoodBye!!");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        private static bool DecisionForNextTime()
        {
            Console.WriteLine("Do you want to do another process(y=yes,n=No)?");
            string ques = Console.ReadLine();
            if (ques.Equals("y"))
                return true;
            else
                return false;

        
         }
    }
}
