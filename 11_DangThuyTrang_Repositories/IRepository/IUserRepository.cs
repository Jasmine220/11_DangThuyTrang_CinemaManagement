
using _11_DangThuyTrang_BussinessObjects.Models;

namespace _11_DangThuyTrang_Repositories.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        void UpdateStatus(int userId, bool newStatus);
    }
}
