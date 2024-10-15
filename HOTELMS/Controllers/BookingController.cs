using HOTELMS.Context;
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

        public IActionResult Create(Booking booking)
        {

            _dbcontext.Bookings.Add(booking);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var Bookings = _dbcontext.Bookings.ToList();
            return Ok(Bookings);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var booking = _dbcontext.Bookings.Find(id);
            return Ok(booking);
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
