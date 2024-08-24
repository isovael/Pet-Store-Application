using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Store_Application
{
    public class ProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashes;
        private Dictionary<string, CatFood> _catFoods;
        public ProductLogic()
        {
            _products = new List<Product>();
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

    }



}