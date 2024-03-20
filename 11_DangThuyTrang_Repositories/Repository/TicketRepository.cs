﻿using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.Repository
{
	public class TicketRepository: ITicketRepository
	{
		public List<MovieDTO> ShowStatistic() => TicketDAO.ShowStatistic(); 

    }
}
