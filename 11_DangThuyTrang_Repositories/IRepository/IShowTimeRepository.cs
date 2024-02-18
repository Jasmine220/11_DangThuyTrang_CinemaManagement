using _11_DangThuyTrang_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.IRepository
{
    public interface IShowTimeRepository
    {
        List<ShowTime> GetShowTimesByDate(DateTime date);
        ShowTime GetShowTimeById(int id);
	}
}
