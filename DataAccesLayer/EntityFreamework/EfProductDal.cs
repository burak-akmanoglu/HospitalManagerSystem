using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFreamework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> ListProduct()
        {
            using (var c = new Context())
            {
                return c.Products.Include(ba => ba.Storehouse).ToList();
            }

        }
    }
}
