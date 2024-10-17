namespace HOTELMS.DTOS
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public string RoomNumbers { get; set; }

        public int HotelId { get; set; }
    }
}
