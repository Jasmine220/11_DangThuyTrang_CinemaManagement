using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
	public class GenreDAO
	{
		public static List<Genre> GetGenres()
		{
			var ListGenres = new List<Genre>();
			try
			{
				using (var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					ListGenres = context.Genres.Include(g => g.Movies).ToList();
				}
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return ListGenres;
		}
	}
}
