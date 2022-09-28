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
    public class RoomManager : IRoomService
    {
        IRoomDal _roomDal;

        public RoomManager(IRoomDal RoomDal)
        {
            _roomDal = RoomDal;
        }

        public void TAdd(Room t)
        {
            _roomDal.Insert(t);
        }

        public void TDelete(Room t)
        {
           _roomDal.Delete(t);
        }

        public Room TGetByID(int id)
        {
           return _roomDal.GetById(id);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public void TUpdate(Room t)
        {
            _roomDal.Update(t);
        }
        public List<Room> ListRoom()
        {
            return _roomDal.ListRoom();
        }
    }
}
