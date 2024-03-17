using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .Include (st => st.Showroomseat).ThenInclude(st => st.Showroom).ThenInclude(s => s.ShowRoomSeats).ThenInclude(s => s.Seat)
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
}
