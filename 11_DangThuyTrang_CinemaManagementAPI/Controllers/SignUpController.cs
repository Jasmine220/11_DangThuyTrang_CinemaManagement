using _11_DangThuyTrang_DataAccess.DTO;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpRepository _authRepository = new SignUpRepository();
        [HttpPost]
        public IActionResult SignUp([FromBody] SignUpRequest request)
        {
            if (request == null)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }

            var user = _authRepository.CreateUser(request.Phone, request.Email, request.Address);
            if (user == null)
            {
                return BadRequest("Không thể tạo người dùng");
            }
            var account = _authRepository.CreateAccount(user, request.Username, request.Password);
            if (account == null)
            {
                return BadRequest("Không thể tạo tài khoản");
            }
            return Ok("Đăng ký thành công");
        }

    }
}
