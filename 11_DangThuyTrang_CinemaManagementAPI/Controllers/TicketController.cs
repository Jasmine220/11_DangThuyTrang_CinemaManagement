using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private ITicketRepository repository = new TicketRepository();
        [HttpGet("statistic")]
        public IActionResult ShowStatistic()
        {
            try
            {
                var movieDTOs = repository.ShowStatistic();
                return Ok(movieDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetTicketsByUserId(int userId)
        {
            try
            {
                var tickets = repository.GetTicketsByUserId(userId);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetTicketsByTicketId(int id)
        {
            try
            {
                var tickets = repository.GetTicketsByTicketId(id);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
