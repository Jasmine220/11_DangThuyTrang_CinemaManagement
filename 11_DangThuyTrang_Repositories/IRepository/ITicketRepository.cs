using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;

namespace _11_DangThuyTrang_Repositories.IRepository
{
	public interface ITicketRepository
	{
		public List<Ticket> GetTicketsByListId(List<int> ids);
        List<int> CreateTicket(int showtimeId, int paymentMethodId, string showroomseatIds, int customerId, int showRoomId);

        public StatisticResponse ShowStatistic();

	}
}
