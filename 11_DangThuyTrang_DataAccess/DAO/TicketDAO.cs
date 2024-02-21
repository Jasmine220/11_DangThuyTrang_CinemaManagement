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
                    .Include (st => st.Showroomseat)
                    .Include(st => st.Showtime)
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
}
