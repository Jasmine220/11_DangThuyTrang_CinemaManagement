using _11_DangThuyTrang_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.IRepository
{
	public interface ITicketRepository
	{
		public Ticket GetTicketById(int id);

    }
}
