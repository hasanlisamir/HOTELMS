using HOTELMS.Context;
using HOTELMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        

        private readonly HOTELMSDbContext _dbcontext;


        public HotelController(HOTELMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        [HttpPost]

        public IActionResult Create(Hotel hotel)
        {

            _dbcontext.Hotels.Add(hotel);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var Hotels = _dbcontext.Hotels.ToList();
            return Ok(Hotels);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _dbcontext.Hotels.Find(id);
            return Ok(hotel);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var hotel = _dbcontext.Hotels.Find(id);
            if (hotel != null)
            {

                _dbcontext.Remove(hotel);

                _dbcontext.SaveChanges();

            }
            return Ok();

        }
        }
    }
