﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_BussinessObjects.DTO.Response
{
    public class StatisticResponse
    {
        public List<DailyRevenue> DailyRevenues { get; set; }
        public List<MovieResponse> MovieDTOs { get; set; }
    }
}
