﻿using DataAccesLayer.Abstract;
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
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        public List<Room> ListRoom()
        {
            using (var c = new Context())
            {
                return c.Rooms.Include(ba => ba.Building).ToList();
            }

        }
    }
}
