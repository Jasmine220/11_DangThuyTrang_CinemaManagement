using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_BussinessObjects.DTO
{
    public  class LoginResponse
    {
        public bool IsLoggedIn { get; set; }
        public int Role { get; set; }
        public int UserId { get; set; }
    }
}
