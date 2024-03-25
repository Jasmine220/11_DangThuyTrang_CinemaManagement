using System.Collections.Generic;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        public void UpdateStatus(int userId, bool newStatus) => UserDao.UpdateStatus(userId, newStatus);

        public List<User> GetAllUsers() => UserDao.GetAllUsers();
    }
}
