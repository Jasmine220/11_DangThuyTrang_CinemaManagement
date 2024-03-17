namespace _11_DangThuyTrang_CinemaManagementClient.DTO.Response
{
    public class ShowRoomSeatResponse
    {
        public int ShowroomseatId { get; set; }
        public int? ShowroomId { get; set; }
        public int? SeatId { get; set; }
        public bool? Status { get; set; }
        public string? Type { get; set; }
    }
}
