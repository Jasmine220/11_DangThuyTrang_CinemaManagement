using System;
using System.Collections.Generic;

namespace _11_DangThuyTrang_BussinessObjects.Models
{
    public partial class Movie
    {
        public Movie()
        {
            ShowTimes = new HashSet<ShowTime>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int? Length { get; set; }
        public string Language { get; set; }
        public DateTime? PurchaseTime { get; set; }
        public string Rated { get; set; }
        public string Image { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
