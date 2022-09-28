using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagerSystemWeb.Controllers
{
    public class ProductController : Controller
    {
        string Baseurl = "https://localhost:7258/";
        //public void _ViewBag()
        //{

        //    TaskStatuseManager Ts = new TaskStatuseManager(new EfTaskStatuseDal());

        //    List<SelectListItem> umValue = (from i in Um.TGetList()
        //                                    select new SelectListItem
        //                                    {
        //                                        Text = i.UserName,
        //                                        Value = i.UserID.ToString()
        //                                    }).ToList();
        //    ViewBag.Us = umValue;
        //}
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken == "User not found") { return Redirect("~/Login/"); }
            List<Product> CliInfo = new List<Product>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage Res = await client.GetAsync("api/Product");
                if (Res.IsSuccessStatusCode)
                {
                    var CliResponse = Res.Content.ReadAsStringAsync().Result;

                    CliInfo = JsonConvert.DeserializeObject<List<Product>>(CliResponse);
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
            if (accessToken == "User not found") { return Redirect("~/Login/"); }
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            if (accessToken != null)
            {
                return View();
            }
            return Redirect("~/Login/");
        }
        [HttpPost]
        public IActionResult Create(Product parametre)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //client.DefaultRequestHeaders.Clear();
                string data = JsonConvert.SerializeObject(parametre);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/api/Product/AddProduct", content).Result;
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
                Product productdata = new Product();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/api/Product/GetbyIdProduct" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    productdata = JsonConvert.DeserializeObject<Product>(data);
                }
                if (accessToken != null)
                {
                    return View(productdata);
                }
                return null;
            }
        }
        public IActionResult Edit(Product parametre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                var response = client.PutAsJsonAsync(client.BaseAddress + "/api/Product/UpdateProduct", parametre).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View("Details", parametre.ProductId);
            }
        }
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage result = client.DeleteAsync(client.BaseAddress + "​/api​/Product​/DeleteProduct/?id=" + id).Result;

                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
