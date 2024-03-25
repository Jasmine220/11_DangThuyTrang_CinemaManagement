using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_CinemaManagementClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Text.Json;
using _11_DangThuyTrang_BussinessObjects.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        private string _userApiUrl = "";
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _userApiUrl = "https://localhost:7230/api/User";
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync(int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;
            string apiUrlUser = $"{_userApiUrl}/GetAllUsers";


            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMovies = await client.GetAsync(apiUrlUser);
                if (!responseMovies.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error", "Home");
                }
                string strDataUser = await responseMovies.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<User> listUser = JsonSerializer.Deserialize<List<User>>(strDataUser, options);

                ViewBag.TotalPages = (int)Math.Ceiling((double)listUser.Count() / pageSize);
                listUser = listUser.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                if (HttpContext.Session.GetString("IsLoggedIn") != "true" || HttpContext.Session.GetString("UserRole") != "1")
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(listUser);
            }
        }


        public async Task<IActionResult> UpdateStatus(int userId, bool newStatus)
        {
            string apiUrlUpdateStatus = $"{_userApiUrl}/UpdateStatus/{userId}&{newStatus}";


            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsync(apiUrlUpdateStatus,null);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách người dùng sau khi cập nhật thành công
                }
                else
                {
                    // Xử lý lỗi nếu cần
                    ModelState.AddModelError(string.Empty, "Lỗi khi cập nhật trạng thái người dùng.");
                    return View("Error");
                }
            }
        }


    }
}