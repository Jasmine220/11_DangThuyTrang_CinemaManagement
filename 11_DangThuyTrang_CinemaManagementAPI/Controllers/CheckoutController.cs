using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : Controller
    {
        private ITicketRepository repository = new TicketRepository();
        [HttpGet]
        public IActionResult GetTicketById([FromQuery] List<int> ids)
        {
            try
            {
                var ticket = repository.GetTicketsByListId(ids);
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
