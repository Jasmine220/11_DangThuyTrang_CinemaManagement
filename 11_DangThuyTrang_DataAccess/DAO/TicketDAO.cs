using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class TicketDAO
    {
        public static Ticket GetTicketById(int id)
        {
            Ticket? ticket = null;
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    ticket = context.Tickets
                    .Include(st => st.PaymentMethod)
                    .Include(st => st.Customer)
                    .Include(st => st.Showroomseat).ThenInclude(st => st.Showroom).ThenInclude(s => s.ShowRoomSeats).ThenInclude(s => s.Seat)
                    .Include(st => st.Showtime).ThenInclude(st => st.Movie)
                    .SingleOrDefault(s => s.Id == id);
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting ticket by id.", ex);
            }
            return ticket;
        }

        public static Ticket CreateTicket(int showtimeId, int paymentMethodId, int showroomseatId)
        {
            using (var context = new _11_DangThuyTrang_CinemaManagementContext())
            {
                var showTime = ShowtimeDAO.GetShowTimeById(showtimeId);
                var showRoomSeat = ShowRoomSeatDAO.GetShowRoomSeatById(showroomseatId);
                var paymentMethod = PaymentMethodDAO.GetPaymentMethodById(paymentMethodId);
                if (showTime == null)
                {
                    throw new ApplicationException("Show time not found.");
                }
                if (showRoomSeat == null)
                {
                    throw new ApplicationException("Show room seat not found.");
                }
                if (paymentMethod == null)
                {
                    throw new ApplicationException("Payment method not found.");
                }
                double totalPrice = (double)showTime.Movie.PriceTicket;
                if (showRoomSeat.Type != null && showRoomSeat.Type.Equals("vip"))
                {
                    totalPrice += 25000;
                }
                var ticket = new Ticket
                {
                    TotalPrice = totalPrice,
                    CustomerId = 1,
                    CreatedTime = new DateTime(),
                    Quantity = 1,
                    ShowtimeId = showtimeId,
                    PaymentMethodId = paymentMethodId,
                    PaymentMethod = paymentMethod,
                    ShowroomseatId = showroomseatId,
                    Showroomseat = showRoomSeat,
                };
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return ticket;
            }
        }

        public static StatisticResponse ShowStatistic()
        {
            using (var context = new _11_DangThuyTrang_CinemaManagementContext())
            {
                List<DailyRevenue> dailyRevenues = new List<DailyRevenue>();
                //get ticket from db

                // Lấy dữ liệu trong vòng 1 tháng gần đây (có thể điều chỉnh)
                var tickets = context.Tickets.Where(t => t.CreatedTime <= DateTime.Now.AddMonths(1)).ToList();

                // Nhóm và tính toán tổng doanh thu theo ngày
                dailyRevenues = tickets.GroupBy(t => t.CreatedTime.Date)
                    .Select(group => new DailyRevenue
                    {
                        Date = group.Key,
                        Amount = (double)group.Sum(t => t.TotalPrice)

                    })
                    .OrderBy(r => r.Date)
                    .ToList();

                var ticketDetails = context.Tickets.Include(st => st.Showtime).ThenInclude(m => m.Movie).ToList();

                var topSaledMovies = ticketDetails.GroupBy(td => td.Showtime.MovieId)
                    .Select(group => new
                    {
                        MovieId = group.Key,
                        Sale = group.Sum(td => td.Quantity.Value)
                    })
                    .OrderByDescending(item => item.Sale)
                    .Take(10)
                    .ToList();

                //get movieIds
                var movieIds = topSaledMovies.Select(item => item.MovieId).ToList();
                //get MovieName
                var movieNames = context.Movies.Where(m => movieIds.Contains(m.Id))
                    .Select(m => new
                    {
                        m.Id,
                        m.Title
                    })
                    .ToList();
                var result = topSaledMovies.Join(movieNames, tp => tp.MovieId, p => p.Id, (tp, p) => new { tp.MovieId, p.Title, tp.Sale }).ToList();

                List<MovieDTO> moviesDTO = new List<MovieDTO>();
                foreach (var movie in result)
                {
                    moviesDTO.Add(new MovieDTO
                    {
                        MovieId = (int)movie.MovieId,
                        Title = movie.Title,
                        Sale = movie.Sale
                    });
                }
                StatisticResponse statisticResponse = new StatisticResponse
                {
                    DailyRevenues = dailyRevenues,
                    MovieDTOs = moviesDTO,
                };
                return statisticResponse;
            }

        }

    }

}
