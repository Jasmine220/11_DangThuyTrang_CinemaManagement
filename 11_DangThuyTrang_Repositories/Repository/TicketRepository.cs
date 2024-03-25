using _11_DangThuyTrang_BussinessObjects.DTO.Response;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public List<int> CreateTicket(int showtimeId, int paymentMethodId, string showroomseatIds, int customerId, int showRoomId) => TicketDAO.CreateTicket(showtimeId, paymentMethodId, showroomseatIds, customerId, showRoomId);

        public List<Ticket> GetTicketsByListId(List<int> ids) => TicketDAO.GetTicketsByListId(ids);

        public StatisticResponse ShowStatistic() => TicketDAO.ShowStatistic();

        public List<Ticket> GetTicketsByUserId(int userId) => TicketDAO.GetTicketsByUserId(userId);
        public Ticket GetTicketsByTicketId(int id) => TicketDAO.GetTicketByTicketId(id);
    }
}
