using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
	public class MovieManagementController : Controller
	{
		private readonly HttpClient client = null;
		private string MovieApiUrl = "";
		public MovieManagementController()
		{
			client = new HttpClient();
			var contentType = new MediaTypeWithQualityHeaderValue("application/json");
			client.DefaultRequestHeaders.Accept.Add(contentType);
			MovieApiUrl = "https://localhost:7230/api/Movie";
		}
		public async Task<IActionResult> Index(string? keyword)
		{
			HttpResponseMessage response = await client.GetAsync($"{MovieApiUrl}/GetAllMovie?keyword={keyword}");
			string strData = await response.Content.ReadAsStringAsync();
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			List<Movie> listProducts = JsonSerializer.Deserialize<List<Movie>>(strData, options);
			ViewBag.Keyword = keyword;
            if (HttpContext.Session.GetString("IsLoggedIn") != "true" || HttpContext.Session.GetString("UserRole") != "1")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(listProducts);
		}
		public async Task<IActionResult> Detail(int id)
		{
			HttpResponseMessage response = await client.GetAsync(MovieApiUrl + "/Detail/" + id);

			Movie product = new Movie();
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				string strData = await response.Content.ReadAsStringAsync();
				var options = new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				};
				product = JsonSerializer.Deserialize<Movie>(strData, options);
			}
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(product);
		}

		public async Task<ActionResult> Create()
		{
			HttpResponseMessage response2 = await client.GetAsync("https://localhost:7230/api/Movie/GetAllGenre");
			string strData2 = await response2.Content.ReadAsStringAsync();
			var options2 = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			List<Genre> genreList = JsonSerializer.Deserialize<List<Genre>>(strData2, options2);
			ViewData["GenreList"] = genreList;
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Movie p)
		{
			HttpResponseMessage response = await client.PostAsJsonAsync(MovieApiUrl+ "/AddMovie", p);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Create");
		}
        public async Task<ActionResult> Edit(int id)
        {
            // Lấy thông tin movie từ API
            HttpResponseMessage response = await client.GetAsync(MovieApiUrl + "/Detail/" + id);
            Movie product = new Movie();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                product = response.Content.ReadFromJsonAsync<Movie>().Result;
            }

            // Lấy danh sách genre từ API
            HttpResponseMessage response2 = await client.GetAsync("https://localhost:7230/api/Movie/GetAllGenre");
            string strData2 = await response2.Content.ReadAsStringAsync();
            var options2 = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Genre> genreList = JsonSerializer.Deserialize<List<Genre>>(strData2, options2);

            // Kiểm tra xem phản hồi từ API có thành công không trước khi gán giá trị cho genreList
            if (genreList != null)
            {
                ViewData["GenreList"] = genreList;
            }
          /*  if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }*/
            return View(product);
        }
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Movie p)
		{
			await client.PutAsJsonAsync(MovieApiUrl + "/Update", p);
			return RedirectToAction("Index");
		}
		public async Task<ActionResult> Delete(int id)
		{
			await client.DeleteAsync(MovieApiUrl + "/Delete/" + id);
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index");
		}
	}
}
