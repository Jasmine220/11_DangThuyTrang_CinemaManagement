using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class ShowTime
    {
        public ShowTime()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string? StartTime { get; set; }
        public int ShowroomId { get; set; }
        public int MovieId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual ShowRoom Showroom { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
