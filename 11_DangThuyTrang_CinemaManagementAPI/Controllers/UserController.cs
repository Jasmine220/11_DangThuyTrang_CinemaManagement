using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository=new UserRepository();

    

        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("UpdateStatus/{userId}&{newStatus}")]
        public IActionResult UpdateUserStatus(int userId, bool newStatus)
        {
            try
            {
                _userRepository.UpdateStatus(userId, newStatus);
                return Ok(); 
            }
            catch
            {
                return StatusCode(500, "Lỗi khi cập nhật trạng thái người dùng."); // Trả về lỗi server nếu có lỗi xảy ra
            }
        }
    }
}
