using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Service.Controllers
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
        public async Task<IActionResult> CreatePayment (PaymentInformationModel model)
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
                return Redirect(link.value);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> PaymentCallback()
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
