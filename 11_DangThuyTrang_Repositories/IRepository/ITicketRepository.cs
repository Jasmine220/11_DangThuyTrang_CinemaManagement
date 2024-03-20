using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;

namespace _11_DangThuyTrang_Repositories.IRepository
{
	public interface ITicketRepository
	{
		public Ticket GetTicketById(int id);
		public StatisticResponse ShowStatistic();

	}
}
