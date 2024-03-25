namespace _11_DangThuyTrang_CinemaManagementClient.DTO.Request
{
    public class TicketRequest
    {
        public string ShowTimeId { get; set; }
        public string[] ShowRoomSeatIds { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
