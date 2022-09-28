using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagerSystemWeb.Controllers
{
    public class BuildingController : Controller
    {
        string Baseurl = "https://localhost:7258/";
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == "User not found") { return Redirect("~/Login/"); }
            List<Building> CliInfo = new List<Building>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage Res = await client.GetAsync("api/Building");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    CliInfo = JsonConvert.DeserializeObject<List<Building>>(CliResponse);
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
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (accessToken != null)
            {
                return View();
            }
            return Redirect("~/Login/");
        }
        [HttpPost]
        public IActionResult Create(Building parametre)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                string data = JsonConvert.SerializeObject(parametre);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "api/Building/AddBuilding", content).Result;
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


                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                Building udata = new Building();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage result = client.DeleteAsync(client.BaseAddress + "api/Building/GetbyIdBuilding/?id=" + id).Result;

                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    udata = JsonConvert.DeserializeObject<Building>(data);
                }
                if (accessToken != null)
                {
                    return View(udata);
                }
                return null;
            }
        }
        public IActionResult Edit(Building parametre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PutAsJsonAsync(client.BaseAddress + "api/Building/UpdateBuilding/", parametre).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Details", parametre.BuildingId);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = client.DeleteAsync(client.BaseAddress + "api/Building/DeleteBuilding/?id=" + id).Result;

                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }

            }

            return RedirectToAction("Index");
        }
    }
}
