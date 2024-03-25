using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_BussinessObjects.DTO
{
    public class MovieDetailDTO
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        public DateTime PurchaseTime { get; set; }
        public int Length { get; set; }
        public string Language { get; set; }
        public string Rated { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
