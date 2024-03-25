using _11_DangThuyTrang_BussinessObjects.DTO.Response;
using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class TicketDAO
    {
        public static List<Ticket> GetTicketsByListId(List<int> ids)
        {
            List<Ticket> tickets = new List<Ticket>();
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    tickets = context.Tickets
                        .Include(st => st.PaymentMethod)
                        .Include(st => st.Customer)
                        .Include(st => st.Showroomseat).ThenInclude(st => st.Showroom).ThenInclude(s => s.ShowRoomSeats).ThenInclude(s => s.Seat)
                        .Include(st => st.Showtime).ThenInclude(st => st.Movie)
                        .Where(ticket => ids.Contains(ticket.Id))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting tickets by list of ids.", ex);
            }
            return tickets;
        }

        public static List<int> CreateTicket(int showtimeId, int paymentMethodId, string showroomseatIds, int customerId, int showRoomId)
        {
            List<int> ticketIds = new List<int>();

            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var showTime = ShowtimeDAO.GetShowTimeById(showtimeId);
                    var paymentMethod = PaymentMethodDAO.GetPaymentMethodById(paymentMethodId);
                    if (showTime == null)
                    {
                        throw new ApplicationException("Show time not found.");
                    }

                    var seatNames = showroomseatIds.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var seatName in seatNames)
                    {
                        var seat = context.Seats.FirstOrDefault(s => s.Name == seatName);
                        if (seat == null)
                        {
                            throw new ApplicationException($"Seat with name {seatName} not found.");
                        }
                        // Lấy ShowRoomSeat dựa trên Id của ghế
                        var showRoomSeat = ShowRoomSeatDAO.GetShowRoomSeatById(seat.Id, showRoomId);
                        if (showRoomSeat == null)
                        {
                            throw new ApplicationException($"Show room seat with ID {seat.Id} not found.");
                        }

                        double totalPrice = (double)showTime.Movie.PriceTicket;
                        if (showRoomSeat.Type != null && showRoomSeat.Type.Equals("vip", StringComparison.OrdinalIgnoreCase))
                        {
                            totalPrice += 25000;
                        }

                        var ticket = new Ticket
                        {
                            TotalPrice = totalPrice,
                            CustomerId = customerId,
                            CreatedTime = DateTime.Now,
                            Quantity = 1,
                            ShowtimeId = showtimeId,
                            PaymentMethodId = null,
                            ShowroomseatId = showRoomSeat.ShowroomseatId,
                        };

                        context.Tickets.Add(ticket);
                        context.SaveChanges();

                        // Add the newly created ticket ID to the list
                        ticketIds.Add(ticket.Id);
                    }

                    // Update seat status after creating tickets
                    foreach (var seatName in seatNames)
                    {
                        var seat = context.Seats.FirstOrDefault(s => s.Name == seatName);
                        var showRoomSeat = ShowRoomSeatDAO.GetShowRoomSeatById(seat.Id, showRoomId);
                        if (seat != null)
                        {
                            ShowRoomSeatDAO.UpdateSeatStatus(showRoomSeat.ShowroomseatId);
                        }
                    }
                }

                return ticketIds;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating ticket.", ex);
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

                List<MovieResponse> moviesDTO = new List<MovieResponse>();
                foreach (var movie in result)
                {
                    moviesDTO.Add(new MovieResponse
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

        public static List<Ticket> GetTicketsByUserId(int userId)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var tickets = context.Tickets
                        .Include(ticket => ticket.Customer)
                        .Include(ticket => ticket.PaymentMethod)
                        .Include(ticket => ticket.Showroomseat).ThenInclude(showroomseat => showroomseat.Seat)
                        .Include(ticket => ticket.Showroomseat).ThenInclude(showroomseat => showroomseat.Showroom)
                        .Include(ticket => ticket.Showtime).ThenInclude(showtime => showtime.Movie)
                        .Where(ticket => ticket.CustomerId == userId)
                        .ToList();

                    return tickets;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting tickets by user id including all foreign keys.", ex);
            }
        }

        public static Ticket GetTicketByTicketId(int ticketId)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var ticket = context.Tickets
                        .Include(ticket => ticket.Customer)
                        .Include(ticket => ticket.PaymentMethod)
                        .Include(ticket => ticket.Showroomseat).ThenInclude(showroomseat => showroomseat.Seat)
                        .Include(ticket => ticket.Showroomseat).ThenInclude(showroomseat => showroomseat.Showroom)
                        .Include(ticket => ticket.Showtime).ThenInclude(showtime => showtime.Movie)
                        .FirstOrDefault(ticket => ticket.Id == ticketId);

                    return ticket;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting ticket by ticket ID including all foreign keys.", ex);
            }
        }

    }

}
