using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Mvc;


namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimeController : Controller
    {
        private IShowTimeRepository repository = new ShowTimeRepository();

        [HttpGet("bydate")]
        public IActionResult GetShowTimesByDate(DateTime date)
        {
            try
            {
                var showTimes = repository.GetShowTimesByDate(date);
                return Ok(showTimes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

		[HttpGet("{id}")]
		public IActionResult GetShowTimeById(int id)
		{
			try
			{
				var showTime = repository.GetShowTimeById(id);
				return Ok(showTime);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}
	}
}
