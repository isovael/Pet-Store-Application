﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Store_Application
{
    public interface IProductLogic
    {
        void AddProduct(Product product);
        public List<Product> GetAllProducts();
        public DogLeash GetDogLeashByName(string name);
        public CatFood GetCatFoodByName(string name);
        public List<string> GetOnlyInStockProducts();
    }
}
