using System;

//PetShopApp Excercise 5

public static class ListExtensions
{
    public static List<Product> InStock<Product>(this List<T> list)
    {
        return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();


    }
}
