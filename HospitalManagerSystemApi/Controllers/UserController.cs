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
    public class UserController : ControllerBase
    {
        UserManager userManager = new UserManager(new EfUserDal());

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var dp = userManager.TGetList();
            return Ok(dp);
        }
        [HttpPost("AddUser")]
        public IActionResult Add([FromBody] User p)
        {
            userManager.TAdd(p);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetbyIdUser")]
        public IActionResult GetId(int id)
        {

            var item = userManager.TGetByID(id);
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
        [HttpDelete("DeleteUser")]
        public IActionResult Delete(int id)
        {
            var values = userManager.TGetByID(id);
            userManager.TDelete(values);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateUse")]
        public IActionResult Update(User parametre)
        {
            userManager.TUpdate(parametre);
            return NoContent();

        }
    }
}
