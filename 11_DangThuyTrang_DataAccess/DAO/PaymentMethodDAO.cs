using _11_DangThuyTrang_BussinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DangThuyTrang_DataAccess.DAO
{
	public class PaymentMethodDAO
	{
		public static PaymentMethod GetPaymentMethodById(int id)
		{
			PaymentMethod paymentMethod = null;
			try
			{
				using(var context = new _11_DangThuyTrang_CinemaManagementContext())
				{
					paymentMethod = context.PaymentMethods.FirstOrDefault(p => p.Id == id);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error getting payment method", ex);
			}
			return paymentMethod;
		}
	}
}
