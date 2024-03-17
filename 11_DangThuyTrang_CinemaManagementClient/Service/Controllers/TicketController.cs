using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_CinemaManagementClient.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Service.Controllers
{
    public class TicketController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient client = null;
        private string ShowRoomSeatApiUrl = "";
        private string ShowRoomApiUrl = "";
        private string ShowTimeApiUrl = "";
        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ShowRoomSeatApiUrl = "https://localhost:7230/api/ShowRoomSeat";
            ShowRoomApiUrl = "https://localhost:7230/api/ShowRoom";
            ShowTimeApiUrl = "https://localhost:7230/api/ShowTime";
        }
        public async Task<IActionResult> Index(int? showroomId, int? showtimeId)
        {
            HttpResponseMessage responseShowRoomSeat = await client.GetAsync($"{ShowRoomSeatApiUrl}/?showroomId=1");
            HttpResponseMessage responseShowRoom = await client.GetAsync($"{ShowRoomApiUrl}/1");
            HttpResponseMessage responseShowTime = await client.GetAsync($"{ShowTimeApiUrl}/1");

            string strDataShowRoomSeat = await responseShowRoomSeat.Content.ReadAsStringAsync();
            string strDataShowRoom = await responseShowRoom.Content.ReadAsStringAsync();
            string strDataShowTime = await responseShowTime.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<ShowRoomSeat> showRoomSeats = JsonSerializer.Deserialize<List<ShowRoomSeat>>(strDataShowRoomSeat, options);
            ShowRoom showRoom = JsonSerializer.Deserialize<ShowRoom>(strDataShowRoom, options);
            ShowTime showTime = JsonSerializer.Deserialize<ShowTime>(strDataShowTime, options);
            //showRoomSeats = showRoomSeats.OrderBy(s => s.Seat.Name).ToList();

            DateTime date;
            string dateString = "";
            if (DateTime.TryParse(showTime.Date.ToString(), out date))
            {
                dateString = date.ToShortDateString();
            }
            BookingTicketResponse response = new BookingTicketResponse
            {
                TheaterId = showRoom.TheaterId,
                TheaterName = showRoom.Theater.Name,
                NumberSeat = showRoom.NumberSeat,
                StartTime = showTime.StartTime,
                Date = dateString,
                MovieId = showTime.MovieId,
                MovieTitle = showTime.Movie.Title,
                MovieImage = showTime.Movie.Image,
                PriceTicket = showTime.Movie.PriceTicket,
                ShowRoomId = showRoom.Id,
                ShowRoomName = showRoom.Name,
                ShowRoomSeats = showRoomSeats
            };
            return View(response);
        }

    }
}
