using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.IRepository
{
    public interface IMovieRepository
    {
        void SaveMovie(MovieRequestDTO movie);
        Movie GetMovietById(int id);
        void DeleteMovie(Movie p);
        void UpdateMovie(UpdateMovieDTO movie);
        List<Movie> GetMovies(string? keyword);
        List<Genre> GetGenres();
        List<Movie> GetAllMovies();
        MovieDetailDTO? GetMovieDetail(int movieId);
    }
}
