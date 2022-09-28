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
    public class EfStorehouseDal : GenericRepository<Storehouse>, IStorehouseDal
    {
        public List<Storehouse> ListStorehouse()
        {
            using (var c = new Context())
            {
                return c.Storehouses.Include(ba => ba.Building).ToList();
            }

        }
    }
}
