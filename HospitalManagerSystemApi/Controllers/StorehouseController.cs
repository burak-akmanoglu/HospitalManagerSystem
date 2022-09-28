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
    public class StorehouseController : ControllerBase
    {
        StorehouseManager storehouseManager = new StorehouseManager(new EfStorehouseDal());
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var dp = storehouseManager.ListStorehouse();
            return Ok(dp);
        }
        [Authorize]
        [HttpPost("AddStorehouse")]
        public IActionResult Add([FromBody] Storehouse p)
        {
            storehouseManager.TAdd(p);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetbyIdStorehouse")]
        public IActionResult GetId(int id)
        {

            var item = storehouseManager.TGetByID(id);
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
        [HttpDelete("DeleteStorehouse")]
        public IActionResult Delete(int id)
        {
            var values = storehouseManager.TGetByID(id);
            storehouseManager.TDelete(values);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateStorehouse")]
        public IActionResult Update(Storehouse parametre)
        {
            storehouseManager.TUpdate(parametre);
            return NoContent();

        }
    }


}
