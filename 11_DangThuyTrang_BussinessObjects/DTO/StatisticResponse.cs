using _11_DangThuyTrang_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_BussinessObjects.DTO
{
    public class StatisticResponse
    {
        public List<DailyRevenue> DailyRevenues {  get; set; }
       public  List<MovieDTO> MovieDTOs { get; set; }
    }
}
