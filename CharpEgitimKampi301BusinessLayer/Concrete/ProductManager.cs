using CharpEgitimKampi301.DataAccessLayer.EntityFramework;
using CharpEgitimKampi301.EntiyLayer.Concrete;
using CharpEgitimKampi301BusinessLayer.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharpEgitimKampi301BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductService _productService;
        private EFProductDal eFProductDal;

        public ProductManager(IProductService productService)
        {
            _productService = productService;
        }

        public ProductManager(EFProductDal eFProductDal)
        {
            this.eFProductDal = eFProductDal;
        }

        public void TDelete(Product entity)
        {
            _productService.TDelete(entity);
        }

        public List<Product> TGetAll()
        {
            return _productService.TGetAll();
        }

        public Product TGetById(int id)
        {
            return _productService.TGetById(id);
        }

        public void TInsert(Product entity)
        {
            _productService.TInsert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productService.TUpdate(entity);
        }
    }
}
