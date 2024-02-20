using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class ShowRoom
    {
        public ShowRoom()
        {
            ShowTimes = new HashSet<ShowTime>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? NumberSeat { get; set; }
        public string Type { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; }
        public int? TheaterId { get; set; }

        public virtual Theater Theater { get; set; }
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
