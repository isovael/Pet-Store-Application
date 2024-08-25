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
            //write to console instructions
            Console.WriteLine("Press 1 to add a Cat Food product.");
            Console.WriteLine("Press 2 to view an existing Cat Food product.");
            Console.WriteLine("Press 3 to add a Dog Leash product.");
            Console.WriteLine("Press 4 to view an existing Dog Leash product.");
            Console.WriteLine("Press 0 to view in-stock products.");
            Console.WriteLine("Type 'exit' to quit");
            //user input variable:
            string userInput = Console.ReadLine();
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
                    //back into the product while statement:
                    Console.WriteLine("Press 1 to add another Cat Food product.");
                    Console.WriteLine("Press 2 to view an existing Cat Food product.");
                    Console.WriteLine("Press 3 to add a Dog Leash product.");
                    Console.WriteLine("Press 4 to view an existing Dog Leash product.");
                    Console.WriteLine("Press 0 to view in-stock products.");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();
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
                    Console.WriteLine("Press 1 to add a Cat Food product.");
                    Console.WriteLine("Press 2 to view another existing Cat Food product.");
                    Console.WriteLine("Press 3 to add a Dog Leash product.");
                    Console.WriteLine("Press 4 to view an existing Dog Leash product.");
                    Console.WriteLine("Press 0 to view in-stock products.");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();
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
                    Console.WriteLine("Press 1 to add a Cat Food product.");
                    Console.WriteLine("Press 2 to view an existing Cat Food product.");
                    Console.WriteLine("Press 3 to add another Dog Leash product.");
                    Console.WriteLine("Press 4 to view an existing Dog Leash product.");
                    Console.WriteLine("Press 0 to view in-stock products.");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();

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
                    Console.WriteLine("Press 1 to add a Cat Food product.");
                    Console.WriteLine("Press 2 to view an existing Cat Food product.");
                    Console.WriteLine("Press 3 to add a Dog Leash product.");
                    Console.WriteLine("Press 4 to view another existing Dog Leash product.");
                    Console.WriteLine("Press 0 to view in-stock products.");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();
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
                    Console.WriteLine("Press 1 to add a Cat Food product.");
                    Console.WriteLine("Press 2 to view an existing Cat Food product.");
                    Console.WriteLine("Press 3 to add a Dog Leash product.");
                    Console.WriteLine("Press 4 to view an existing Dog Leash product.");
                    Console.WriteLine("Press 0 to view in-stock products.");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                    Console.WriteLine("Press 1 to add a Cat Food product.");
                    Console.WriteLine("Press 2 to view an existing Cat Food product.");
                    Console.WriteLine("Press 3 to add a Dog Leash product.");
                    Console.WriteLine("Press 4 to view an existing Dog Leash product."); 
                    Console.WriteLine("Press 0 to view in-stock products.");
                    Console.WriteLine("Type 'exit' to quit");
                    userInput = Console.ReadLine();
                }

            }

        }

        

    }
}