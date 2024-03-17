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
        public ActionResult<bool> Login([FromBody] LoginRequest request) => repository.Login(request.Username, request.Password);
    }
}
