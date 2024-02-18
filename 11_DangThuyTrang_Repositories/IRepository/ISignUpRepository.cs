using _11_DangThuyTrang_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.IRepository
{
    public interface ISignUpRepository
    {
        public Account CreateAccount(string username, string password);
        public User CreateUser(int accountId, string phone, string email, string address);
        public Role GetRoleById(int roleId);
    }
}
