using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_BussinessObjects.DTO
{
    public class TicketRequest
    {
        public int ShowTimeId { get; set; }
        public int PaymentMethodId { get; set; }
        public string ShowRoomSeatIds { get; set; }
        public int CustomerId { get; set; }
        public int ShowRoomId { get; set; }
    }
}
