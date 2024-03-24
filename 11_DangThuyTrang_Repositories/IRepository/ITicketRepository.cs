using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using System.Collections.Generic;

namespace _11_DangThuyTrang_Repositories.IRepository
{
    public interface ITicketRepository
    {
        List<Ticket> GetTicketsByListId(List<int> ids);

        StatisticResponse ShowStatistic();

        List<Ticket> GetTicketsByUserId(int userId);
        Ticket GetTicketsByTicketId(int userId);
    }
}
