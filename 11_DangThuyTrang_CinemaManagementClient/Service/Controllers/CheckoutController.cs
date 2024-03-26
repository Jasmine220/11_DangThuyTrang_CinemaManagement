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
        public CheckoutController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            CheckoutApiUrl = "https://localhost:7230/api/Checkout";
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(int showTimeId, string showRoomSeatIds, decimal totalPrice, int showroomId)
        {
            try
            {
                var customerId = HttpContext.Session.GetInt32("UserId");
                // Gọi API để tạo vé
                var request = new
                {
                    ShowTimeId = showTimeId,
                    ShowRoomSeatIds = showRoomSeatIds,
                    TotalPrice = totalPrice,
                    CustomerId = customerId,
                    ShowRoomId = showroomId
                };

                var response = await client.PostAsJsonAsync(CheckoutApiUrl + "/CreateTicket", request);
                response.EnsureSuccessStatusCode();

                // Đọc dữ liệu phản hồi từ API
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<int> ticketIds = JsonSerializer.Deserialize<List<int>>(strData, options);
                HttpContext.Session.Set("TicketIds", JsonSerializer.SerializeToUtf8Bytes(ticketIds));

                // Chuyển hướng đến trang Ticket và truyền danh sách ID của các vé được tạo
                return RedirectToAction("Ticket", new { ids = ticketIds });
            }
            catch (HttpRequestException)
            {
                return BadRequest("Failed to create tickets.");
            }
        }


        public async Task<IActionResult> Ticket(List<int> ids)
        {
            HttpResponseMessage response = await client.GetAsync($"{CheckoutApiUrl}?{string.Join("&", ids.Select(id => $"ids={id}"))}");
            List<Ticket> tickets = new List<Ticket>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string strData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                tickets = JsonSerializer.Deserialize<List<Ticket>>(strData, options);
            }
            if (HttpContext.Session.GetString("IsLoggedIn") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            return View(tickets);
        }

    }
}
