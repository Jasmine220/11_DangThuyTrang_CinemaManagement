using _11_DangThuyTrang_BussinessObjects.DTO;

namespace _11_DangThuyTrang_CinemaManagementAPI.Service
{
    public interface IVNPayService
    {
        string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
