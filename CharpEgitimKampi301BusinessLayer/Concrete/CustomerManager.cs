using CharpEgitimKampi301.DataAccessLayer.Abstract;
using CharpEgitimKampi301.EntiyLayer.Concrete;
using CharpEgitimKampi301BusinessLayer.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharpEgitimKampi301BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
           _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
           return  _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if(entity.CustomerName !="" && entity.CustomerName.Length>=3 && 
                entity.CustomerCity!=null && entity.CustomerSurname!=""&&
                entity.CustomerSurname.Length <= 30)
            {
                _customerDal.Insert(entity);
            }
            else
            {
                //Hata Mesajı  
            }
                
        }

        public void TUpdate(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
