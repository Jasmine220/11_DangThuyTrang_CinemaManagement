using _11_DangThuyTrang_BussinessObjects.DTO;
using _11_DangThuyTrang_BussinessObjects.Models;
using _11_DangThuyTrang_CinemaManagementAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace _11_DangThuyTrang_CinemaManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VNPayController : Controller
    {
        private readonly IVNPayService _vnPayService;

        public VNPayController(IVNPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost(Name = "create-payment")]
        public Link CreatePaymentUrl(PaymentInformationModel model)
        {
            Link link = new Link();
            link.name = model.Name;
            link.value = _vnPayService.CreatePaymentUrl(model, HttpContext);
            return link;
        }
        [HttpGet]
        public IActionResult PaymentCallback()
        {
            PaymentResponseModel response = (PaymentResponseModel)_vnPayService.PaymentExecute(Request.Query);
            ViewBag.Response = response;
            return View("/Views/Result.cshtml", response);
        }
        public static IActionResult Index()
        {
            return null;
        }
    }
}
