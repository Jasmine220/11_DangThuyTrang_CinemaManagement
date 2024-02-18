using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
	public class ShowroomDAO
	{
		public static ShowRoom GetShowRoomById(int id)
		{
			ShowRoom showRoom = null;
			try
			{
				using(var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					//showRoom = context.ShowRooms.Include(sr => sr.Theater)
					//	.Join(context.ShowRoomSeats, 
					//			showroom => showRoom.Id,
					//			showroomseat => showroomseat.ShowroomId,
					//			(showroom, showroomseat) => new
					//			{
					//				id = showroom.Id,
					//				name = showroom.Name,
					//				numberSeat = showroom.NumberSeat,
					//				type = showroom.Type,
					//				showrostatus = showroom.Status,
					//				image = showroom.Image,
					//				seatId = showroomseat.Seat,
					//				theater = showroom.Theater,
					//			}
					showRoom = context.ShowRooms.Include(sr => sr.Theater).FirstOrDefault(sr => sr.Id == id);
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error getting show room by id.", ex);
			}
			return showRoom;
		}
	}
}
