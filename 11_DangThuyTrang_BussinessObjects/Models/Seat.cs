using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
