using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShowRoomController : ControllerBase
	{
		private IShowRoomRepository repository = new ShowRoomRepository();
		[HttpGet("{id}")]
		public IActionResult GetShowRoomById(int id)
		{
			try
			{
				var showRoom = repository.GetShowRoomById(id);
				return Ok(showRoom);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}
	}
}
