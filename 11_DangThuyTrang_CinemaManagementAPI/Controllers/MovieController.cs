using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DTO;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private IMovieRepository repository = new MovieRepository();

        [HttpGet("GetAllMovie")]
        public ActionResult<IEnumerable<Movie>> GetMovies(string? keyword)
        {
            var products = repository.GetMovies(keyword);
            return products;
        }
        [HttpGet("GetAllGenre")]
        public ActionResult<IEnumerable<Genre>> GetGenres() => repository.GetGenres();

        [HttpPost("AddMovie")]
        public IActionResult AddMovie(MovieRequestDTO p)
        {
            repository.SaveMovie(p);
            return NoContent();
        }
        [HttpGet("Detail/{id}")]
        public ActionResult<Movie> GetMovieById(int id) => repository.GetMovietById(id);
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var p = repository.GetMovietById(id);
            if (p == null)
            {
                return NotFound("Cannot find movie");
            }
            repository.DeleteMovie(p);
            return NoContent();
        }
        [HttpPut("Update")]
        public IActionResult UpdateMovie(UpdateMovieDTO p)
        {
            var pro = repository.GetMovietById(p.Id);
            if (pro == null)
            {
                return NotFound("Cannot find Movie");
            }
            repository.UpdateMovie(p);
            return NoContent();
        }

        [HttpGet("GetAllMovies")]
        public ActionResult<IEnumerable<Movie>> GetAllMovies(string? keyword, int? genreId)
        {
            var movies = repository.GetAllMovies(keyword, genreId);
            return Ok(movies);
        }

        [HttpGet("{movieId}")]
        public IActionResult GetMovieDetail(int movieId)
        {
            try
            {
                var movieDetail = repository.GetMovieDetail(movieId);
                if (movieDetail == null)
                {
                    return NotFound();
                }
                return Ok(movieDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
