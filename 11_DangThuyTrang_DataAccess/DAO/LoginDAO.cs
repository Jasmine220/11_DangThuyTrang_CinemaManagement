using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class LoginDAO
    {
        public static (bool IsLoggedIn, int RoleId, int UserId) Login(LoginRequest l)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var account = context.Accounts
                        .Include(a => a.IdNavigation.UserRoles)
                            .ThenInclude(ur => ur.Role)
                        .FirstOrDefault(a => a.Username == l.Username && a.Password == l.Password);

                    if (account != null && account.IdNavigation != null)
                    {
                        // Lấy quyền của người dùng từ đối tượng User liên quan
                        var userRole = account.IdNavigation.UserRoles.FirstOrDefault();
                        if (userRole != null && userRole.Role != null)
                        {
                            return (true, userRole.Role.Id, account.Id); // Trả về cả Id của người dùng
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return (false, 0, 0);
        }
    }
}
