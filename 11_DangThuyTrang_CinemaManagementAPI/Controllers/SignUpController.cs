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
        public IActionResult SignUp(string username, string password, string phone, string email, string address)
        {
            var user = _authRepository.CreateUser(phone, email, address);
            if (user == null)
            {
                return BadRequest("Không thể tạo người dùng");
            }
            var account = _authRepository.CreateAccount(user, username, password);
            if (account == null)
            {
                return BadRequest("Không thể tạo tài khoản");
            }
            return Ok("Đăng ký thành công");
        }
    }
}
