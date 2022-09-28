using BusinessLayerApi.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerApi.Concrete
{
    public class StorehouseManager : IStorehouseService
    {
        IStorehouseDal _storehouseDal;
        public StorehouseManager(IStorehouseDal StorehouseDal)
        {
            _storehouseDal = StorehouseDal;
        }

        public void TAdd(Storehouse t)
        {
            _storehouseDal.Insert(t);
        }

        public void TDelete(Storehouse t)
        {
            _storehouseDal.Delete(t);
        }

        public Storehouse TGetByID(int id)
        {
            return _storehouseDal.GetById(id);
        }

        public List<Storehouse> TGetList()
        {
            return _storehouseDal.GetList();
        }

        public void TUpdate(Storehouse t)
        {
            _storehouseDal.Update(t);
        }
        public List<Storehouse> ListStorehouse()
        {
            return _storehouseDal.ListStorehouse();
        }
    }
}
