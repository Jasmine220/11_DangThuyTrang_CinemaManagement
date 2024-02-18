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
            // Tạo tài khoản và nhận Id trả về
            var account = _authRepository.CreateAccount(username, password);

            // Kiểm tra xem tài khoản có được tạo thành công không
            if (account == null)
            {
                return BadRequest("Không thể tạo tài khoản");
            }

            // Tạo người dùng với Id từ tài khoản mới tạo
            var user = _authRepository.CreateUser(account.Id, phone, email, address);

            // Kiểm tra việc tạo người dùng có thành công không
            if (user == null)
            {
                return BadRequest("Không thể tạo người dùng");
            }

            return Ok("Đăng ký thành công");
        }
    }
}
