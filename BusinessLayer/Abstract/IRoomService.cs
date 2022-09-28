using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerApi.Abstract
{
    public interface IRoomService : IGenericService<Room>
    {
        List<Room> ListRoom();
    }
}
