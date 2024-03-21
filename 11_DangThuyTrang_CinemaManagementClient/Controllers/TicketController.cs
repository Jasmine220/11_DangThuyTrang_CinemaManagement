using _11_DangThuyTrang_BussinessObjects.DTO.Response;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_CinemaManagementClient.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Controllers
{
    public class TicketController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient client = null;
        private readonly BillService _billService;
        private string ShowRoomSeatApiUrl = "";
        private string ShowRoomApiUrl = "";
        private string ShowTimeApiUrl = "";
        private string TicketApiUrl = "";
        public TicketController(IConfiguration configuration)
        {
            _configuration = configuration;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ShowRoomSeatApiUrl = "https://localhost:7230/api/ShowRoomSeat";
            ShowRoomApiUrl = "https://localhost:7230/api/ShowRoom";
            ShowTimeApiUrl = "https://localhost:7230/api/ShowTime";
            TicketApiUrl = "https://localhost:7230/api/Ticket";
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
            showRoomSeats = showRoomSeats.OrderBy(s => s.Seat.Name).ToList();

            List<ShowRoomSeat> rowA = showRoomSeats.Where(s => s.Seat.Name.Contains("A")).ToList();
            List<ShowRoomSeat> rowB = showRoomSeats.Where(s => s.Seat.Name.Contains("B")).ToList();
            List<ShowRoomSeat> rowC = showRoomSeats.Where(s => s.Seat.Name.Contains("C")).ToList();
            List<ShowRoomSeat> rowD = showRoomSeats.Where(s => s.Seat.Name.Contains("D")).ToList();
            List<ShowRoomSeat> rowE = showRoomSeats.Where(s => s.Seat.Name.Contains("E")).ToList();
            List<ShowRoomSeat> rowF = showRoomSeats.Where(s => s.Seat.Name.Contains("F")).ToList();
            List<ShowRoomSeat> rowG = showRoomSeats.Where(s => s.Seat.Name.Contains("G")).ToList();
            List<ShowRoomSeat> rowH = showRoomSeats.Where(s => s.Seat.Name.Contains("H")).ToList();
            List<ShowRoomSeat> rowJ = showRoomSeats.Where(s => s.Seat.Name.Contains("J")).ToList();
            List<ShowRoomSeat> rowK = showRoomSeats.Where(s => s.Seat.Name.Contains("K")).ToList();
            List<ShowRoomSeat> rowL = showRoomSeats.Where(s => s.Seat.Name.Contains("L")).ToList();

            //display showroomseat by row
            ViewBag.rowA = rowA;
            ViewBag.rowB = rowB;
            ViewBag.rowC = rowC;
            ViewBag.rowD = rowD;
            ViewBag.rowE = rowE;
            ViewBag.rowF = rowF;
            ViewBag.rowG = rowG;
            ViewBag.rowH = rowH;
            ViewBag.rowJ = rowJ;
            ViewBag.rowK = rowK;
            ViewBag.rowL = rowL;

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
                MovieId = (int)showTime.MovieId,
                MovieTitle = showTime.Movie.Title,
                MovieImage = showTime.Movie.Image,
                PriceTicket = showTime.Movie.PriceTicket,
                ShowRoomId = showRoom.Id,
                ShowRoomName = showRoom.Name,
                ShowRoomSeats = showRoomSeats,
                ShowTimeId = showtimeId,
            };
            return View(response);
        }

        public async Task<IActionResult> Statistic()
        {
            HttpResponseMessage responseTicket = await client.GetAsync($"{TicketApiUrl}/statistic");

            string strData = await responseTicket.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            StatisticResponse statisticResponse = JsonSerializer.Deserialize<StatisticResponse>(strData, options);
            List<MovieResponse> movieDTOs = statisticResponse.MovieDTOs;
            List<DailyRevenue> dailyRevenues = statisticResponse.DailyRevenues;

            //save to view data
            ViewData["TopProducts"] = movieDTOs;
            return View(dailyRevenues);
        }

    }
}
