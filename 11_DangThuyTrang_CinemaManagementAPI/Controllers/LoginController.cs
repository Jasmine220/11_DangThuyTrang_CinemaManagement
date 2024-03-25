using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_DataAccess.DTO;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginRepository repository = new LoginRepository();

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = repository.Login(request.Username, request.Password);
            

            if (result.IsLoggedIn)
            {
                LoginResponse response = new LoginResponse
                {
                    IsLoggedIn = result.IsLoggedIn,
                    Role = result.RoleId,
                };
                return Ok(response); // Trả về HTTP 200 OK nếu đăng nhập thành công
            }
            else
            {
                return Unauthorized(); // Trả về HTTP 401 Unauthorized nếu đăng nhập không thành công
            }
        }
    }
}
