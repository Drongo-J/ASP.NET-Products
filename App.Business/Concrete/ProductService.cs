using App.Business.Abstract;
using App.DataAccess.Abstract;
using App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int id)
        {
            _productDal.Delete(GetById(id));
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public List<Product> GetRandomProducts(int count)
        {
            var products = GetAll();
            if (count < 0 || count > products.Count)
                return null!;
            var randomProducts = new List<Product>();
            do
            {
                int rand = new Random().Next(0, products.Count);
                var product = products[rand];
                if (!randomProducts.Contains(product))
                {
                    randomProducts.Add(products[rand]);
                }
            } while (randomProducts.Count != count);
            return randomProducts;
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
