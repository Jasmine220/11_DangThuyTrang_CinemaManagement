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
        public Account CreateAccount(User uses, string username, string password);
        public User CreateUser(string phone, string email, string address);
    }
}
