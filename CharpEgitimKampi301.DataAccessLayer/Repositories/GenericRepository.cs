using CharpEgitimKampi301.DataAccessLayer.Abstract;
using CharpEgitimKampi301.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharpEgitimKampi301.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal1<T> where T : class
    {
        KampContext context=new KampContext();
        readonly  DbSet<T> _object;
        public GenericRepository()
        {
            _object=context.Set<T>();
        }
        public void Delete(T entity)
        {
            var deletedEntiy=context.Entry(entity);
            deletedEntiy.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T entity)
        {
            var addetEntiy=context.Entry(entity);
            addetEntiy.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updatedEntity=context.Entry(entity);
            updatedEntity.State= EntityState.Modified;
        }
    }
}
