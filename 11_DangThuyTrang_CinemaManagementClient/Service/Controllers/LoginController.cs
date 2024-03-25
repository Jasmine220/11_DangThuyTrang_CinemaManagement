using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7230/api/Login";
        }
        public ActionResult Index()
        {
            HttpContext.Session.Remove("IsLoggedIn");
            HttpContext.Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginRequest login)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl, login);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var loginResult = JsonSerializer.Deserialize<(bool IsLoggedIn, int RoleId)>(responseBody);

                if (loginResult.IsLoggedIn)
                {
                    // Thêm thông tin đăng nhập và vai trò vào HttpContext
                    HttpContext.Session.SetString("IsLoggedIn", "true");
                    HttpContext.Session.SetString("UserRole", loginResult.RoleId.ToString());

                    return Redirect("/Home/Index");
                }
            }

            TempData["ErrorMessage"] = "Invalid email or password.";
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("IsLoggedIn");
            HttpContext.Session.Remove("UserRole");
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
