using _11_DangThuyTrang_BussinessObjects.Models;

namespace _11_DangThuyTrang_CinemaManagementClient.DTO.Response
{
    public class BookingTicketResponse
    {
        public BookingTicketResponse()
        {
            ShowRoomSeats = new HashSet<ShowRoomSeat>();
        }
        //showroom
        public int ShowRoomId { get; set; }
        public string? ShowRoomName { get; set; }
        public int? NumberSeat { get; set; }
        public int? TheaterId { get; set; }
        public string? TheaterName { get; set; }

        //showtime
        public string? StartTime { get; set; }
        public DateTime? Date { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieImage { get; set; }
        public double? PriceTicket { get; set; }
        //list showroomseat
        public virtual ICollection<ShowRoomSeat> ShowRoomSeats { get; set; }
    }
}
