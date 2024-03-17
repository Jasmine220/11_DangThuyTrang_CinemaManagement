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
        public static bool Login(string username, string password)
        {
            bool isLogin = false;
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var mem = context.Accounts.FirstOrDefault(i => i.Username == username && i.Password == password);
                    if (mem != null)
                    {
                        isLogin = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return isLogin;
        }
    }
}
