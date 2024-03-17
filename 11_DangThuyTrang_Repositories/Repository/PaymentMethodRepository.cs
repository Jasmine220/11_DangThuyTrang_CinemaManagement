using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_DataAccess.DAO;
using _11_DangThuyTrang_Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_Repositories.Repository
{
	public class PaymentMethodRepository : IPaymentMethodRepository
	{
		public PaymentMethod GetPaymentMethodById(int id)=> PaymentMethodDAO.GetPaymentMethodById(id);
	}
}
