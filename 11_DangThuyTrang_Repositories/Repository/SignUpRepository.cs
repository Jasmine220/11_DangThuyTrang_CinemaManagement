using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class SignUpRepository : ISignUpRepository
    {
        public Account CreateAccount(string username, string password) => SignUpDAO.CreateAccount(username, password);

        public User CreateUser(int accountId, string phone, string email, string address) => SignUpDAO.CreateUser(accountId, phone, email, address);

        public Role GetRoleById(int roleId) => SignUpDAO.GetRoleById(roleId);
    }
}
