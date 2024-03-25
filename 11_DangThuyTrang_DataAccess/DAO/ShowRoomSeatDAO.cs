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

		public static ShowRoomSeat GetShowRoomSeatById(int showRoomSeatId, int showRoomId)
		{
			ShowRoomSeat? showRoomSeat = null;
			try
			{
				using (var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					showRoomSeat = context.ShowRoomSeats.FirstOrDefault(s => s.SeatId == showRoomSeatId && s.ShowroomId == showRoomId);
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error getting show room seat", ex);
			}
			return showRoomSeat;
		}

		public static void UpdateShowRoomSeats(int showroomId, int[] seatIds)
		{
			List<ShowRoomSeat> showRoomSeats = null;
			try
			{
				using (var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					showRoomSeats = context.ShowRoomSeats.Where(s => seatIds.ToList().Contains((int)s.SeatId) && s.ShowroomId == showroomId).ToList();
					if (showRoomSeats.Count == 0)
					{

						throw new ApplicationException("Seats not found");
					}
					foreach (var seat in showRoomSeats)
					{
						seat.Status = true;
					}
					context.ShowRoomSeats.UpdateRange(showRoomSeats);
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error update show room seats.", ex);
			}
		}
		public static void UpdateSeatStatus(int showRoomSeatId)
		{
			try
			{
				using (var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					var showRoomSeat = context.ShowRoomSeats.FirstOrDefault(s => s.ShowroomseatId == showRoomSeatId);
					if (showRoomSeat != null)
					{
						showRoomSeat.Status = true;
						context.SaveChanges();
					}
					else
					{
						throw new ApplicationException($"Show room seat with ID {showRoomSeatId} not found.");
					}
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error updating show room seat status.", ex);
			}
		}
	}
}
