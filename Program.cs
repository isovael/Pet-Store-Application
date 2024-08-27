using Pet_Store_Application;
using System;
using System.ComponentModel;
using System.Text.Json;
using System.Xml.Linq;
using static Pet_Store_Application.Product;
using static Pet_Store_Application.ProductLogic;
using static System.Net.Mime.MediaTypeNames;



namespace Pet_Store_Application

{


    class Program
    {

        static void Main()
        {
;

            var productLogic = new ProductLogic();
            var menuOptions = new MenuOptions();
            //while loop:
            while (userInput.ToLower() != "exit")
            {

                //if add product:
                if (userInput == "1")
                {
                    //cat food object:
                    CatFood catFood = new CatFood();
                    //user prompt and input lines:
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the Cat Food name:");
                    catFood.Name = Console.ReadLine();
                    Console.WriteLine("Added " + catFood.Name + " successfully.");
                    Console.WriteLine("Please enter the product Quantity:");
                    catFood.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Added " + catFood.Quantity + " units of " + catFood.Name + " successfully.");
                    //Add Product
                    productLogic.AddProduct(catFood);
                    Console.WriteLine("");
                    Console.WriteLine("Added item successfully.");
                    var menuOptions.MenuOptions();
                }
                if (userInput == "2")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a Cat Food name.");
                    userInput= Console.ReadLine();
                    var catFoodReturn = productLogic.GetCatFoodByName(userInput);
                    if (catFoodReturn != null)
                    {
                        Console.WriteLine("There are " + catFoodReturn.Quantity + " units of " + catFoodReturn.Name + " in stock.");
                    }
                    if ( (catFoodReturn == null))
                    {
                        Console.WriteLine("No product found with that name.");
                    }
                    Console.WriteLine("");
                    var menuOptions.MenuOptions();
                }
                if(userInput == "3")
                {
                    //dog leash object:
                    DogLeash dogLeash = new DogLeash();
                    //user prompt and input lines:
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the Dog Leash name:");
                    dogLeash.Name = Console.ReadLine();
                    Console.WriteLine("Added " + dogLeash.Name + " successfully.");
                    Console.WriteLine("Please enter the product Quantity:");
                    dogLeash.Quantity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Added " + dogLeash.Quantity + " units of " + dogLeash.Name + " successfully.");
                    //Add Product
                    productLogic.AddProduct(dogLeash);
                    Console.WriteLine("Added item successfully.");
                    //back into the product while statement:
                    Console.WriteLine("");
                    var menuOptions.MenuOptions();

                }
                if (userInput == "4")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a Dog Leash name.");
                    userInput = Console.ReadLine();
                    var dogLeashesReturn = productLogic.GetDogLeashByName(userInput);
                    if (dogLeashesReturn != null)
                    {
                        Console.WriteLine("There are " + dogLeashesReturn.Quantity + " units of " + dogLeashesReturn.Name + " in stock.");
                    }
                    if (dogLeashesReturn == null)
                    {
                        Console.WriteLine("No product found with that name.");
                    }
                    Console.WriteLine("");
                    var menuOptions.MenuOptions();
                }
                if(userInput == "0")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Current In-Stock Products:\n");
                    //foreach loop to spit out each product in stock name
                    foreach (var product in productLogic.GetOnlyInStockProducts())
                    {
                        Console.WriteLine("\t" + product);
                    }
                    Console.WriteLine("");
                    var menuOptions.MenuOptions();
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                    var menuOptions.MenuOptions();
                }

            }

        }

        

    }
}