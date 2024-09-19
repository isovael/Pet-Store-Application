using Microsoft.Extensions.DependencyInjection;
using Pet_Store_Application;
using System;
using System.ComponentModel;
using System.Text.Json;
using System.Xml.Linq;
using static Pet_Store_Application.Product;
using static Pet_Store_Application.ProductLogic;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.Results;
using FluentValidation;





namespace Pet_Store_Application

{


    class Program
    {
        //Class Excercise 7
        private static IServiceProvider CreateServiceCollection()
        {
            return new ServiceCollection()
            .AddTransient<IProductLogic, ProductLogic>()
            .BuildServiceProvider();
            
            
        }
        
        static void Main()
        {
           
            var services = CreateServiceCollection();
      
           var productLogic = services.GetService<IProductLogic>();

            var menuOptions = new MenuOptions();
            var userInput = menuOptions.ShowMenuOptions();

            //while loop:
            while (userInput.ToLower() != "exit")
            {

                //if add product:
                if (userInput == "1")
                //THIS OPTION ONLY TAKES JSON INPUT, FOR TESTING USE: { "Price": 58.89, "Name": "Special dog leash", "Quantity": 23, "Description": "Magical leash that will help your dog not pull hard when going on walks" }
                {
                    //user prompt and input lines:
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the Cat Food details:");                    
                    string jsonString = Console.ReadLine();
                    CatFood catFood = JsonSerializer.Deserialize<CatFood>(jsonString)!;
                    ProductValidator validator = new ProductValidator();
                    ValidationResult result = validator.Validate(catFood);
                    
                    if (result.IsValid)
                    {
                        Console.WriteLine($"Name: {catFood.Name}");
                        Console.WriteLine($"Quantity: {catFood.Quantity}");
                        Console.WriteLine($"Price: {catFood.Price}");
                        Console.WriteLine($"Description: {catFood.Description}");
                        productLogic.AddProduct(catFood);
                        Console.WriteLine("");
                        Console.WriteLine("Added item successfully.");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                    userInput = menuOptions.ShowMenuOptions();
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
                    userInput = menuOptions.ShowMenuOptions();
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
                    userInput = menuOptions.ShowMenuOptions();

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
                    userInput = menuOptions.ShowMenuOptions();
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
                    userInput = menuOptions.ShowMenuOptions();
                }
                if(userInput == "9")
                {
                    Console.WriteLine("The total value of the current Inventory is: $" + productLogic.GetTotalPriceOfInventory());
                    userInput = menuOptions.ShowMenuOptions();

                }
                else
                {
                    Console.WriteLine("Invalid Input.");
                    userInput = menuOptions.ShowMenuOptions();
                }

            }

        }

        

    }
}