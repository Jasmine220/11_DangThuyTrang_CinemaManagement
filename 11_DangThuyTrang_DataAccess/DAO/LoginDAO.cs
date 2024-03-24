using _11_DangThuyTrang_BussinessObjects.Models;
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
        public static (bool IsLoggedIn, int RoleId) Login(string username, string password)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var account = context.Accounts
                        .Include(a => a.IdNavigation.UserRoles)
                            .ThenInclude(ur => ur.Role)
                        .FirstOrDefault(a => a.Username == username && a.Password == password);

                    if (account != null && account.IdNavigation != null)
                    {
                        // Lấy quyền của người dùng từ đối tượng User liên quan
                        var userRole = account.IdNavigation.UserRoles.FirstOrDefault();
                        if (userRole != null && userRole.Role != null)
                        {
                            return (true, userRole.Role.Id);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            // Trả về kết quả không thành công nếu không tìm thấy thông tin tài khoản hoặc vai trò
            return (false, 0);
        }
    }
}

