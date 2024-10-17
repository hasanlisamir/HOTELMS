using HOTELMS.Context;
using HOTELMS.DTOS;
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

        public IActionResult Create(HotelDto hotelDto)
        {
            var hotel = new Hotel();
            hotel.Id = hotelDto.Id;
            hotel.Name = hotelDto.Name;
            hotel.Description = hotelDto.Description;
            hotel.Phone = hotelDto.Phone;
            hotel.Address = hotelDto.Address;

            _dbcontext.Hotels.Add(hotel);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dtos = new List<HotelDto>();
            var Hotels = _dbcontext.Hotels.ToList();
            foreach (var hotel in Hotels)
            {
                var hotelDto = new HotelDto();
                hotelDto.Id = hotel.Id;
                hotelDto.Address = hotel.Address;
                hotelDto.Name = hotel.Name;
                hotelDto.Phone = hotel.Phone;
                hotelDto.Description = hotel.Description;
                dtos.Add(hotelDto);
            }
            return Ok(dtos);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotelDto = new HotelDto();
            var hotel = _dbcontext.Hotels.Find(id);
            hotelDto.Id = hotel.Id;
            hotelDto.Address = hotel.Address;
            hotelDto.Phone = hotel.Phone;
            hotelDto.Description= hotel.Description;
            hotelDto.Name = hotel.Name;
            return Ok(hotelDto);
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
