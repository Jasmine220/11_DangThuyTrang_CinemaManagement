using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class SignUpDAO
    {
        public static Account CreateAccount(string username, string password)
        {
            using (var context = new _11_DangThuyTrang_CinemaManagementContext())
            {
                // Kiểm tra xem tên người dùng đã tồn tại chưa
                var existingAccount = context.Accounts.FirstOrDefault(a => a.Username == username);
                if (existingAccount != null)
                {
                    throw new ApplicationException("Tên người dùng đã tồn tại.");
                }

                var newAccount = new Account
                {
                    Username = username,
                    Password = password
                };

                context.Accounts.Add(newAccount);
                context.SaveChanges();

                return newAccount;
            }
        }

        public static User CreateUser(int accountId, string phone, string email, string address)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    // Lấy vai trò mặc định từ cơ sở dữ liệu (ví dụ: Customer có ID = 2)
                    int defaultRoleId = 1;
                    var defaultRole = GetRoleById(defaultRoleId);

                    var newUser = new User
                    {
                        Id = accountId, // Sử dụng id của tài khoản vừa được tạo
                        Phone = phone,
                        Email = email,
                        Address = address,
                        //RoleId = defaultRoleId
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();

                    return newUser;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating user.", ex);
            }
        }

        public static Role GetRoleById(int roleId)
        {
            using (var context = new _11_DangThuyTrang_CinemaManagementContext())
            {
                var role = context.Roles.Find(roleId);
                if (role == null)
                {
                    throw new ApplicationException($"Không tìm thấy vai trò với ID {roleId}.");
                }
                return role;
            }
        }
    }
}
