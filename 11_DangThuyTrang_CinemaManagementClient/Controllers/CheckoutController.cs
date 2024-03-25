using _11_DangThuyTrang_BussinessObjects.DTO.Request;
using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly HttpClient client = null;
        private string CheckoutApiUrl = "";
        private string PaymentApiUrl = "";
        public CheckoutController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CheckoutApiUrl = "https://localhost:7230/api/Checkout";
            PaymentApiUrl = "https://localhost:7230/api/VNPay";
        }
        public async Task<IActionResult> Ticket(int id)
        {
            HttpResponseMessage response = await client.GetAsync(CheckoutApiUrl + "/" + id);

            Ticket ticket = new Ticket();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                ticket = JsonSerializer.Deserialize<Ticket>(strData, options);
            }
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(ticket);
        }

        public async Task<IActionResult> ResponseToPayment(string orderType, double amount, string orderDescription, string name)
        {
            PaymentInformationModel paymentInformationModel = new PaymentInformationModel
            {
                OrderType = orderType,
                Amount = amount,
                OrderDescription = orderDescription,
                Name = name
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(PaymentApiUrl, paymentInformationModel);

            res ticket = new Ticket();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                ticket = JsonSerializer.Deserialize<Ticket>(strData, options);
            }
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(ticket);
        }
    }
}
