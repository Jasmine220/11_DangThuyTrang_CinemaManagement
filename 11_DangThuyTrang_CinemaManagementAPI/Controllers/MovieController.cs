using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DTO;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

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

            if (products == null || products.Count == 0)
            {
                return NotFound("Cannot find Movie");
            }

            return products;
        }
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
    }
}
