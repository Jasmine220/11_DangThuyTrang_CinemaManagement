using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class Seat
    {
        public Seat()
        {
            ShowRoomSeats = new HashSet<ShowRoomSeat>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ShowRoomSeat> ShowRoomSeats { get; set; }
    }
}
