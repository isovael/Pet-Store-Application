﻿using System;
using Pet_Store_Application;

//PetShopApp Excercise 5

public static class ListExtensions
{
    public static List<string> InStock (this List<Product> list)
    {
        return list.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
        
    }
}
