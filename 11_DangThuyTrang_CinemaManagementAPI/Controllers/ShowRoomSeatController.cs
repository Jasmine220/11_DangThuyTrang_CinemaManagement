using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShowRoomSeatController : ControllerBase
	{
		private IShowRoomSeatRepository repository = new ShowRoomSeatRepository();
		[HttpGet]
		public IActionResult GetShowRoomSeatsByShowRoomId(int? showroomId)
		{
			try
			{
				var showRoomSeats = repository.GetShowRoomSeats(showroomId);
				return Ok(showRoomSeats);
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal Server Error: {ex.Message}");
			}
		}

	}
}
