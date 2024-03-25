using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class UserDao
    {

        public static List<User> GetAllUsers()
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    return context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                throw new Exception($"Error while getting all users: {ex.Message}");
            }
        }

        public static void UpdateStatus(int userId, bool newStatus)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var user = context.Users.Find(userId);
                    if (user != null)
                    {
                        user.Status = newStatus;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần thiết
                throw new Exception($"Error while updating user status: {ex.Message}");
            }
        }
        
    }
}
