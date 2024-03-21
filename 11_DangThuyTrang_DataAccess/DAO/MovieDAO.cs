using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class MovieDAO
    {
        public static List<Movie>? GetMovies(string? keyword)
        {
            List<Movie>? listMovies = null;
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var query = context.Movies.AsQueryable();
                    if (keyword != null)
                    {
                        query = query.Where(i => !string.IsNullOrEmpty(i.Title) && i.Title.ToLower().Contains(keyword.ToLower()));
                    }
                    listMovies = query.Include(i => i.Genre).AsNoTracking().ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listMovies;
        }
        public static Movie GetMovieById(int movieId)
        {
            Movie p = new Movie();
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    p = context.Movies.Include(i => i.Genre).AsNoTracking().SingleOrDefault(x => x.Id == movieId);

                }
            }
            catch (Exception e) { throw new Exception(e.Message); }
            return p;
        }
        public static void SaveMovie(MovieRequestDTO p)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var pro = new Movie()
                    {
                        Title = p.Title,
                        Description = p.Description,
                        Director = p.Director,
                        Length = p.Length,
                        Language = p.Language,
                        PurchaseTime = p.PurchaseTime,
                        Rated = p.Rated,
                        Image = p.Image,
                        GenreId = p.GenreId,
                        PriceTicket = p.PriceTicket,
                    };
                    context.Movies.Add(pro);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void UpdateMovie(UpdateMovieDTO p)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var pro = new Movie()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        Director = p.Director,
                        Length = p.Length,
                        Language = p.Language,
                        PurchaseTime = p.PurchaseTime,
                        Rated = p.Rated,
                        Image = p.Image,
                        GenreId = p.GenreId,
                        PriceTicket = p.PriceTicket,
                    };
                    context.Entry<Movie>(pro).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static void DeleteMovie(Movie p)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var pro = context.Movies.SingleOrDefault(
                        c => c.Id == p.Id);
                    context.Movies.Remove(pro);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Movie>? GetAllMovies()
        {
            List<Movie>? listMovies = null;
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    listMovies = context.Movies.Include(i => i.Genre).AsNoTracking().ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listMovies;
        }


        public static MovieDetailDTO? GetMovieDetail(int movieId)
        {
            MovieDetailDTO movieDetail;
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                     movieDetail =  context.Movies
                        .Where(m => m.Id == movieId)
                        .Select(m => new MovieDetailDTO
                        {
                            Title = m.Title,
                            Director = m.Director,
                            Actors = "",
                            Genre = m.Genre.Name,
                            PurchaseTime = m.PurchaseTime ?? DateTime.MinValue,
                            Length = m.Length ?? 0,
                            Language = m.Language,
                            Rated = m.Rated,
                            Description = m.Description,
                            Image = m.Image
                        })
                        .FirstOrDefault();
                    string Actors="";
                  var MovieCasts=  context.MovieCasts.Where(x => x.MovieId == movieId).Include(x => x.Cast);
                    foreach(var item in MovieCasts)
                    {
                        Actors += item.Cast.Name +",";
                    }
                    movieDetail.Actors= Actors;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error while getting movie detail: {e.Message}");
            }
            return movieDetail;
        }

    }
}
