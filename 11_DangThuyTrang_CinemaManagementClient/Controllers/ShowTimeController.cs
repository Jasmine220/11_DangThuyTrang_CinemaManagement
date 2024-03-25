using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class ShowTimeController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient client = null;
        private string ShowTimeApiUrl = "";
        public ShowTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ShowTimeApiUrl = "https://localhost:7230/api/ShowTime";
        }
        public async Task<IActionResult> Index(DateTime? date)
        {
            HttpResponseMessage response;
            if (date == null)
            {
                response = await client.GetAsync(ShowTimeApiUrl + "/bydate");

            }
            else
            {
                response = await client.GetAsync(ShowTimeApiUrl + "/bydate?date=" + date);
            }

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<ShowTime> listMems = JsonSerializer.Deserialize<List<ShowTime>>(strData, options);
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(listMems);
        }
    }
}
