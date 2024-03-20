using _11_DangThuyTrang_BussinessObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.IRepository
{
	public interface ITicketRepository
	{
		public List<MovieDTO> ShowStatistic();

    }
}
