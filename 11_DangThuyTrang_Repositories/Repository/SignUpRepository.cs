using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        public Account CreateAccount(User user, string username, string password) => SignUpDAO.CreateAccount(user, username, password);

        public User CreateUser(string phone, string email, string address) => SignUpDAO.CreateUser(phone, email, address);

    }
}
