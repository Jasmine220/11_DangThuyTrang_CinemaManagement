using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;

namespace _11_DangThuyTrang_Repositories.IRepository
{

    public interface ITicketRepository
    {
        List<int> CreateTicket(int showtimeId, int paymentMethodId, string showroomseatIds, int customerId, int showRoomId);
        List<Ticket> GetTicketsByListId(List<int> ids);

        StatisticResponse ShowStatistic();

        List<Ticket> GetTicketsByUserId(int userId);
        Ticket GetTicketsByTicketId(int userId);
    }
}
