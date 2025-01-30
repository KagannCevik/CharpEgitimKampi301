using CharpEgitimKampi301.DataAccessLayer.Abstract;
using CharpEgitimKampi301.EntiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharpEgitimKampi301BusinessLayer.Concrete
{
    public class CatogoryManager : ICategoryService
    {
        private readonly ICategoryDal _catogoryDal;

        public CatogoryManager(ICategoryDal catogoryDal)
        {
            _catogoryDal = catogoryDal;
        }

        public void TDelete(Category entity)
        {
            _catogoryDal.Delete(entity);
        }

        public List<Category> TGetAll()
        {
            return _catogoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
           return _catogoryDal.GetById(id);
        }

        public void TInsert(Category entity)
        {
            _catogoryDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
           _catogoryDal.Update(entity);
        }
    }
}
