using BusinessLayerApi.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFreamework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagerSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var dp = productManager.ListProduct();
            return Ok(dp);
        }
        [Authorize]
        [HttpPost("AddProduct")]
        public IActionResult Add([FromBody] Product p)
        {

            productManager.TAdd(p);
            return Ok();
        }
        [Authorize]
        [HttpGet("GetbyIdProduct")]
        public IActionResult GetId(int id)
        {

            var item = productManager.TGetByID(id);
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
        [HttpDelete("DeleteProduct")]
        public IActionResult Delete(int id)
        {
            var values = productManager.TGetByID(id);
            productManager.TDelete(values);
            return Ok();
        }
        [Authorize]
        [HttpPut("UpdateProduct")]
        public IActionResult Update(Product parametre)
        {
            productManager.TUpdate(parametre);
            return NoContent();

        }


    }
}
