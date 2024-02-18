using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
	public class ShowRoomSeatDAO
	{
		public static List<ShowRoomSeat> GetShowRoomSeats(int? showroomId)
		{
			List<ShowRoomSeat>? showRoomSeats = null;
			try
			{
				using (var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					showRoomSeats = showroomId != null 
						? context.ShowRoomSeats
						.Include(srs => srs.Seat)
						.Where(srs => srs.ShowroomId == showroomId)
						.ToList() 
						: context.ShowRoomSeats.Include(srs => srs.Seat).ToList();
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error getting show room seats.", ex);
			}
			return showRoomSeats;
		}
	}
}
