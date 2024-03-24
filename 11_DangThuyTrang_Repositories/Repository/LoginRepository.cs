using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class LoginRepository : ILoginRepository
    {
        public (bool IsLoggedIn, int RoleId) Login(string username, string password) => LoginDAO.Login(username, password);

    }
}
