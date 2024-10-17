namespace HOTELMS.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//olmuyacaq
        public int RoomId { get; set; }
        public Room Room { get; set; }//olmuyacaq

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}
