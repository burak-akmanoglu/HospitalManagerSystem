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
    public class BuildingManager : IBuildingService
    {
        IBuildingDal _buildingDal;
        public BuildingManager(IBuildingDal BuildingDal)
        {
            _buildingDal = BuildingDal;
        }

        public void TAdd(Building t)
        {
            _buildingDal.Insert(t);
        }

        public void TDelete(Building t)
        {
          _buildingDal.Delete(t);
        }

        public Building TGetByID(int id)
        {
            return _buildingDal.GetById(id);
        }

        public List<Building> TGetList()
        {
            return _buildingDal.GetList();
        }

        public void TUpdate(Building t)
        {
           _buildingDal.Update(t);
        }
    }
}
