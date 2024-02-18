using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementWebClient.DTO
{
    public class AccountUserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
