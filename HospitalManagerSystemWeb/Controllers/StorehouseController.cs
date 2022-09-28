using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagerSystemWeb.Controllers
{
    public class StorehouseController : Controller
    {
        string Baseurl = "https://localhost:7258/";
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == "User not found") { return Redirect("~/Login/"); }
            List<Storehouse> CliInfo = new List<Storehouse>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage Res = await client.GetAsync("/api/Storehouse");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    CliInfo = JsonConvert.DeserializeObject<List<Storehouse>>(CliResponse);
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
        public async Task<IActionResult> Create()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
          
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (accessToken != null)
            {
                List<Building> CliInfo = new List<Building>();
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/Building");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    CliInfo = JsonConvert.DeserializeObject<List<Building>>(CliResponse);
                }
                List<SelectListItem> tsValue = (from i in CliInfo.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.BuildingName,
                                                    Value = i.BuildingId.ToString()
                                                }).ToList();
                ViewBag.fbv = tsValue;
                return View();
            }
            return Redirect("~/Login/");
        }
        [HttpPost]
        public IActionResult Create(Storehouse parametre)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                string data = JsonConvert.SerializeObject(parametre);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/api/Storehouse/AddStorehouse", content).Result;
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
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "​/api​/Storehouse​/GetbyIdStorehouse" + id).Result;
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
        public IActionResult Edit(Storehouse parametre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PutAsJsonAsync(client.BaseAddress + "/api/Storehouse/UpdateStorehouse", parametre).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Details", parametre.StorehouseId);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = client.DeleteAsync(client.BaseAddress + "​/api​/Storehouse​/DeleteStorehouse/?id=" + id).Result;

                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
