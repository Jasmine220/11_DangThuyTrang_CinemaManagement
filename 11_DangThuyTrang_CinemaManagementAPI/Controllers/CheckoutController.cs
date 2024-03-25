using _11_DangThuyTrang_BussinessObjects.DTO;
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
        [HttpPost("CreateTicket")]
        public IActionResult CreateTicket(TicketRequest request)
        {
            try
            {
                // Gọi phương thức tạo vé trong repository
                var ticketIds = repository.CreateTicket(request.ShowTimeId, request.PaymentMethodId, request.ShowRoomSeatIds, request.CustomerId, request.ShowRoomId);

                // Trả về danh sách ID của các vé được tạo thành công
                return Ok(ticketIds);
            }
            catch (Exception ex)
            {
                // Trả về lỗi nếu có lỗi xảy ra
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
