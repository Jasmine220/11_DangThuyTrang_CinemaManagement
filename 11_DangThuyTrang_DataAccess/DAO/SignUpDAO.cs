﻿using _11_DangThuyTrang_BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _11_DangThuyTrang_DataAccess.DAO
{
    public class SignUpDAO
    {
        public static Account CreateAccount(User user, string username, string password)
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
                    Id = user.Id,
                    Username = username,
                    Password = password
                };

                context.Accounts.Add(newAccount);
                context.SaveChanges();

                return newAccount;
            }
        }

        public static User CreateUser(string phone, string email, string address)
        {
            try
            {
                using (var context = new _11_DangThuyTrang_CinemaManagementContext())
                {
                    var newUser = new User
                    {
                        Phone = phone,
                        Email = email,
                        Address = address,
                        Status = true
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges() ;

                    // Gán vai trò Customer cho User
                    var userRole = new UserRole
                    {
                        UserId = newUser.Id, // Sử dụng Id của Account đã được truyền vào
                        RoleId = 2 // ID của Customer
                    };
                    context.UserRoles.Add(userRole);

                    context.SaveChanges();

                    return newUser;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating user.", ex);
            }
        }

    }
}
