using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class Theater
    {
        public Theater()
        {
            ShowRooms = new HashSet<ShowRoom>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Hotline { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ShowRoom> ShowRooms { get; set; }
    }
}
