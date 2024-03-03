using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class ShowtimeDAO
    {
        public static List<ShowTime> GetShowTimesByDate(DateTime date)
        {
            List<ShowTime>? showTimes = null;
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    showTimes = context.ShowTimes
                        .Include(st => st.Movie)
                        .Include(st => st.Showroom)
                        .Where(st => EF.Functions.DateDiffDay(st.Date, date) == 0)
                        .ToList();
                }

                // Gộp các bản ghi có cùng MovieId lại với nhau
                var groupedShowTimes = showTimes.GroupBy(st => st.MovieId)
                                                .Select(group => new ShowTime
                                                {
                                                    Id = group.First().Id,
                                                    StartTime = string.Join(", ", group.Select(st => st.StartTime)),
                                                    ShowroomId = group.First().ShowroomId,
                                                    MovieId = group.Key,
                                                    Date = group.First().Date,
                                                    Movie = group.First().Movie,
                                                    Showroom = group.First().Showroom,
                                                    Tickets = group.SelectMany(st => st.Tickets).ToList()
                                                })
                                                .ToList();

                return groupedShowTimes;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error getting show times by date.", ex);
            }
        }

        public static ShowTime GetShowTimeById(int id)
		{
			ShowTime? showTime = null;
			try
			{
				using (var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					showTime = context.ShowTimes
					.Include(st => st.Movie)
					.Include(st => st.Showroom)
					.SingleOrDefault(s => s.Id == id);
				}

			}
			catch (Exception ex)
			{
				throw new ApplicationException("Error getting show time by id.", ex);
			}
			return showTime;
		}
	}
}
