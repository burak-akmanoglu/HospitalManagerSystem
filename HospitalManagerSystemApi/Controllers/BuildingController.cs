using BusinessLayerApi.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFreamework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagerSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        BuildingManager buildingManager = new BuildingManager(new EfBuildingDal());
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var dp = buildingManager.TGetList();
            return Ok(dp);
        }
        //[Authorize]
        [HttpPost("AddBuilding")]
        public IActionResult Add([FromBody]Building p)
        {

            buildingManager.TAdd(p);
            return Ok();
        }
       // [Authorize]
        [HttpGet("GetbyIdBuilding")]
        public IActionResult GetId(int id)
        {

            var item = buildingManager.TGetByID(id);
            if (item==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
        //[Authorize]
        [HttpDelete("DeleteBuilding")]
        public IActionResult Delete(int id)
        {
            var values = buildingManager.TGetByID(id);
            buildingManager.TDelete(values);
            return Ok();
        }
       // [Authorize]
        [HttpPut("UpdateBuilding")]
        public IActionResult Update(Building parametre)
        {
              buildingManager.TUpdate(parametre);
                return NoContent();
            
        }
    }
}
