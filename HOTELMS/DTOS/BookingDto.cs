namespace HOTELMS.DTOS
{
    public class BookingDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public int Id { get; set; }
        public int CustomerId { get; set; }
    }
}
