using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_CinemaManagementClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Text.Json;
using _11_DangThuyTrang_BussinessObjects.DTO;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client = null;
        private string _movieApiUrl = "";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _movieApiUrl = "https://localhost:7230/api/Movie";
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            HttpResponseMessage response = await _client.GetAsync($"{_movieApiUrl}/GetAllMovie");
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Movie> listProducts = JsonSerializer.Deserialize<List<Movie>>(strData, options);
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(listProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> MovieDetail(int id)
        {
            HttpResponseMessage response = await _client.GetAsync(_movieApiUrl + "/" + id);

            MovieDetailDTO product = new MovieDetailDTO();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                product = JsonSerializer.Deserialize<MovieDetailDTO>(strData, options);
            }
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(product);
        }

    }
}