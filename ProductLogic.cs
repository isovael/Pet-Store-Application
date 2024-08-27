using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pet_Store_Application
{
    public class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashes;
        private Dictionary<string, CatFood> _catFoods;

        public object Quantity { get; private set; }

        public ProductLogic()
        {
             _products = InitProducts();
             _dogLeashes = new Dictionary<string, DogLeash>();
             _catFoods = new Dictionary<string, CatFood>();
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            if (product is DogLeash)
            {
                _dogLeashes.Add(product.Name, product as DogLeash);
            }
            if (product is CatFood)
            {
                _catFoods.Add(product.Name, product as CatFood);
            }
        }
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeashes[name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CatFood GetCatFoodByName(string name)
        {
            try
            {
                return _catFoods[name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //not sure how to get the List extensions from the class to here. 
        public List<string> GetOnlyInStockProducts()
        {
            return GetOnlyInStockProducts().InStock();
            //return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
        }

        //product list of cat foods for prefill in-stock products

        private List<Product> InitProducts()
        {
            return new List<Product>()
         {
           new CatFood
               {
                    Name = "Purina ONE Tender Selects Blend with Real Salmon Dry Cat Food",
                    Price = 23.00m,
                    Description = "This easily digestible adult cat food helps support a microbiome balance in your feline friend and is made with natural prebiotic fiber to promote her gut health and immune support.",
                    Quantity = 15,
                },
                new CatFood
                {
                    Name = "Friskies Seafood Sensations Dry Cat Food",
                    Price = 27.00m,
                    Description = "Loaded with antioxidants to support a healthy immune system plus essential vitamins and minerals for overall well-being.",
                    Quantity = 12,
                },
                new CatFood
                {
                    Name = "Tiki Cat Born Carnivore High Protein Chicken, Herring & Salmon Meal Dry Cat Food",
                    Price = 15.00m,
                    Description = "Crafted with real chicken and herring for the high-quality protein your kitty deserves.",
                    Quantity =0,

                },
                new CatFood
                {
                    Name = "Meow Mix Original Choice Dry Cat Food",
                    Price = 15.00m,
                    Description = "Complete and balanced nutrition for adult cats.",
                    Quantity = 17,
                },



            };
        }
       
    }
}
