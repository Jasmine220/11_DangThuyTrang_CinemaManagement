

using _11_DangThuyTrang_BussinessObjects.Models;
using System.Text.Json;

namespace _11_DangThuyTrang_CinemaManagementClient.Service
{
	public class BillService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly string _billCookieName = "Bill";
		public BillService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

        public BillService()
        {
        }

        public List<Ticket> GetBillFromCookie()
		{
			var billJson = _httpContextAccessor.HttpContext.Request.Cookies[_billCookieName];
			if(!string.IsNullOrEmpty(billJson) )
			{
				//chuyen doi du lieu json trong cookie thanh danh sach ticket
				return JsonSerializer.Deserialize<List<Ticket>>(billJson);
			}
			return new List<Ticket>();
		}

		public void SaveBillToCookie(List<Ticket> bill)
		{
			var billJson = JsonSerializer.Serialize(bill);
			//Lưu giỏ hàng vào cookie
			_httpContextAccessor.HttpContext.Response.Cookies.Append(_billCookieName, billJson,
				new CookieOptions
				{
					//Set life of cookie
					Expires = DateTimeOffset.Now.AddDays(7)
				});
		}

		public void ClearBill()
		{
			_httpContextAccessor.HttpContext.Response.Cookies.Delete(_billCookieName);
		}

		public void AddToBill(Ticket ticket)
		{
			var bill = GetBillFromCookie();
			bill.Add(ticket);
			SaveBillToCookie(bill);
		}
	}
}
