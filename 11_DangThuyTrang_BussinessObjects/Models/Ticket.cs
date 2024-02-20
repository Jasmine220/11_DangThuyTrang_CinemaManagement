using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public double? TotalPrice { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public int? Quantity { get; set; }
        public int? ShowtimeId { get; set; }
        public int? PaymentMethodId { get; set; }

        public virtual User Customer { get; set; }
        public virtual Seat IdNavigation { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual ShowTime Showtime { get; set; }
    }
}
