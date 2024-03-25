using _11_DangThuyTrang_DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.IRepository
{
    public interface ILoginRepository
    {
        public (bool IsLoggedIn, int RoleId, int UserId) Login(LoginRequest l);
    }
}
