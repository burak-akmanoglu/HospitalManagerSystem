using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TcpListenerWeb.Controllers
{
    public class LoginController : Controller
    {
        string Baseurl = "https://localhost:7258/";
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUser user)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7258/api/Login", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    if (token == "Invalid credentials")
                    {
                        ViewBag.Message = "Incorrent UserId or Password!";
                        return Redirect("~/Home/Index");
                    }
                    HttpContext.Session.SetString("JWToken", token);
                }
                return Redirect("~/Building/Index");
            }

        }


        public IActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/User/Index");
        }
    }
}
