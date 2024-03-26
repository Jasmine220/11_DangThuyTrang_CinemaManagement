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

        public async Task<IActionResult> IndexAsync(string? keyword, int? genreId, int? page)
        {
            // Số lượng bản ghi trên mỗi trang
            int pageSize = 8;

            string apiUrlMovies = $"{_movieApiUrl}/GetAllMovies?keyword={keyword}&genreId={genreId}";
            string apiUrlGenres = $"{_movieApiUrl}/GetAllGenre";

            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMovies = await client.GetAsync(apiUrlMovies);
                if (!responseMovies.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error", "Home");
                }
                string strDataMovies = await responseMovies.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Movie> listMovies = JsonSerializer.Deserialize<List<Movie>>(strDataMovies, options);

                // Phân trang
                var pageNumber = page ?? 1;
                var paginatedMovies = listMovies.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                ViewBag.PageNumber = pageNumber;
                ViewBag.TotalPages = Math.Ceiling((double)listMovies.Count / pageSize);

                HttpResponseMessage responseGenres = await client.GetAsync(apiUrlGenres);
                if (!responseGenres.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error", "Home");
                }
                string strDataGenres = await responseGenres.Content.ReadAsStringAsync();
                List<Genre> listGenres = JsonSerializer.Deserialize<List<Genre>>(strDataGenres, options);

                ViewBag.Genres = listGenres;

                return View(paginatedMovies);
            }
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
            return View(product);
        }

    }
}