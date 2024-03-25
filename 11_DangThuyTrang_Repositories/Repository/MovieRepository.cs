using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_DataAccess.DTO;
using _11_DangThuyTrang_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class MovieRepository : IMovieRepository
    {
        public void DeleteMovie(Movie p) => MovieDAO.DeleteMovie(p);

        public List<Movie> GetAllMovies(string? keyword, int? genreId) => MovieDAO.GetAllMovies(keyword, genreId);


        public List<Genre> GetGenres() => GenreDAO.GetGenres();

        public List<Movie> GetMovies(string? keyword) => MovieDAO.GetMovies(keyword);

        public Movie GetMovietById(int id) => MovieDAO.GetMovieById(id);

        public void SaveMovie(MovieRequestDTO movie) => MovieDAO.SaveMovie(movie);

        public void UpdateMovie(UpdateMovieDTO movie) => MovieDAO.UpdateMovie(movie);
        public MovieDetailDTO? GetMovieDetail(int movieId) => MovieDAO.GetMovieDetail(movieId);
    }
}
