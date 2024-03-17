using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_DataAccess.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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
            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody.ToLower() == "true")
            {
                // Thêm thông tin quyền vào HttpContext
                HttpContext.Session.SetString("IsLoggedIn", "true");
                return Redirect("/Home/Index");
            }

            TempData["ErrorMessage"] = "Invalid email or password.";
            return View();
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("IsLoggedIn");
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
