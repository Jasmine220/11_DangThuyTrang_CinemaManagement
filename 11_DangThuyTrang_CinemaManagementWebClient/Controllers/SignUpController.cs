using _11_DangThuyTrang_CinemaManagementWebClient.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace _11_DangThuyTrang_CinemaManagementWebClient.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient client = null;
        private string MemberApiUrl = "";
        public SignUpController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            MemberApiUrl = "https://localhost:7230/api/SignUp";
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(AccountUserRequest model)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(MemberApiUrl, model);
                response.EnsureSuccessStatusCode(); // Đảm bảo thành công

                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return Redirect("/SignUp/Success");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đăng ký không thành công: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
