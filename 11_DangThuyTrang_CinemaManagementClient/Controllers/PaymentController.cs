using _11_DangThuyTrang_BussinessObjects.DTO.Request;
using _11_DangThuyTrang_BussinessObjects.DTO.Response;
using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class PaymentController : Controller
    {
        private readonly HttpClient client = null;
        private string PaymentApiUrl = "";
        public PaymentController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            PaymentApiUrl = "https://localhost:7230/api/VNPay";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(PaymentInformationModel model)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(PaymentApiUrl, model);

                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                Link link = JsonSerializer.Deserialize<Link>(strData, options);
                if (HttpContext.Session.GetString("IsLoggedIn") != "true")
                {
                    return RedirectToAction("Index", "Login");
                }
                return View(link);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> PaymentCallback(int id)
        {
            HttpResponseMessage response = await client.GetAsync(PaymentApiUrl);

            PaymentResponseModel responsePayment = new PaymentResponseModel();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                responsePayment = JsonSerializer.Deserialize<PaymentResponseModel>(strData, options);
            }
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View("/Views/Result.cshtml", response);
        }

    }
}
