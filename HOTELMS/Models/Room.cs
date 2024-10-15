namespace HOTELMS.Models
{
    public class Room
    {

        public int Id { get; set; }
        public int Floor { get; set; }
        public string Description { get; set; }
        public string RoomNumbers { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }


    }
}
