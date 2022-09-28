using BusinessLayerApi.Concrete;
using DataAccesLayer.EntityFreamework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagerSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        RoomManager roomManager = new RoomManager(new EfRoomDal());
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var dp = roomManager.ListRoom();
            return Ok(dp);
        }
        [Authorize]
        [HttpPost("AddRoom")]
        public IActionResult Add([FromBody] Room p)
        {
            roomManager.TAdd(p);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetbyIdRoom")]
        public IActionResult GetId(int id)
        {

            var item = roomManager.TGetByID(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        [Authorize]
        [HttpDelete("DeleteRoom")]
        public IActionResult Delete(int id)
        {
            var values = roomManager.TGetByID(id);
            roomManager.TDelete(values);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateRoom")]
        public IActionResult Update(Room parametre)
        {
            roomManager.TUpdate(parametre);
            return NoContent();

        }
    }
}
