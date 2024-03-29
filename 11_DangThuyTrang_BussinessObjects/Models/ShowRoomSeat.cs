﻿using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class ShowRoomSeat
    {
        public ShowRoomSeat()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ShowroomseatId { get; set; }
        public int? ShowroomId { get; set; }
        public int? SeatId { get; set; }
        public bool? Status { get; set; }
        public string Type { get; set; }

        public virtual Seat? Seat { get; set; }
        public virtual ShowRoom? Showroom { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
