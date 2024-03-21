using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;
using _11_DangThuyTrang_BussinessObjects.DTO.Response;

namespace _11_DangThuyTrang_Repositories.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public Ticket GetTicketById(int id) => TicketDAO.GetTicketById(id);
        public StatisticResponse ShowStatistic() => TicketDAO.ShowStatistic(); 

    }
}
