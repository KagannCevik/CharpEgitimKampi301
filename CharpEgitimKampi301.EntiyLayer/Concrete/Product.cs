using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharpEgitimKampi301.EntiyLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription{ get; set; }
        public int CategotyId { get; set; }
        public virtual Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
