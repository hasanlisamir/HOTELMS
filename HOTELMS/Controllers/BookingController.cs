using HOTELMS.Context;
using HOTELMS.DTOS;
using HOTELMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {


        private readonly HOTELMSDbContext _dbcontext;


        public BookingController(HOTELMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        [HttpPost]

        public IActionResult Create(BookingDto bookingDto)
        {

            Booking booking = new Booking();
            booking.StartDate = bookingDto.StartDate;
            booking.EndDate =bookingDto.EndDate;
            booking.CustomerId = bookingDto.CustomerId; 
            booking.RoomId = bookingDto.RoomId;
            


            _dbcontext.Bookings.Add(booking);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {




            var Bookings = _dbcontext.Bookings.ToList();
            var dtos = new List<BookingDto>();
            foreach (var booking in Bookings)
            {
                var bookingDto = new BookingDto();
                bookingDto.StartDate = booking.StartDate;
                bookingDto.EndDate = booking.EndDate;
                bookingDto.RoomId = booking.RoomId;
                bookingDto.Id = booking.Id;
                bookingDto.CustomerId = booking.CustomerId;
                dtos.Add(bookingDto);
            }
            return Ok(dtos);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var booking = _dbcontext.Bookings.Find(id);

            var bookingDto = new BookingDto();
            bookingDto.StartDate = booking.StartDate;
            bookingDto.EndDate = booking.EndDate;
            bookingDto.RoomId = booking.RoomId;
            bookingDto.Id = booking.Id;
            bookingDto.CustomerId = booking.CustomerId;


            return Ok(bookingDto);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var booking = _dbcontext.Customers.Find(id);
            if (booking != null)
            {

                _dbcontext.Remove(booking);

                _dbcontext.SaveChanges();

            }
            return Ok();


        }
        }
    }
