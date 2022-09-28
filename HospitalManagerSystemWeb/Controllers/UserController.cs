using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagerSystemWeb.Controllers
{
    public class UserController : Controller
    {
        string Baseurl = "https://localhost:7258/";
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == "User not found") { return Redirect("~/Login/"); }
            List<User> CliInfo = new List<User>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage Res = await client.GetAsync("/api/User");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    CliInfo = JsonConvert.DeserializeObject<List<User>>(CliResponse);
                }
                //returning the employee list to view
                if (accessToken != null)
                {
                    return View(CliInfo);
                }
                return Redirect("~/Login/");

            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult Create(User parametre)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                string data = JsonConvert.SerializeObject(parametre);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "api/User/AddUser", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
        }
        public IActionResult Details(int id)
        {
            using (var client = new HttpClient())
            {
                var accessToken = HttpContext.Session.GetString("JWToken");
                if (accessToken == "User not found") { return Redirect("~/Login/"); }

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                Storehouse storehousedata = new Storehouse();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "​/api​/User​/GetbyIdUser" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    storehousedata = JsonConvert.DeserializeObject<Storehouse>(data);
                }
                if (accessToken != null)
                {
                    return View(storehousedata);
                }
                return null;
            }
        }
        public IActionResult Edit(User parametre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PutAsJsonAsync(client.BaseAddress + "/api/User/UpdateUser", parametre).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Details", parametre.Id);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = client.DeleteAsync(client.BaseAddress + "​/api​/User​/DeleteUser/?id=" + id).Result;

                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
