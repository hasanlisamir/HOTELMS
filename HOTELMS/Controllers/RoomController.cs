using HOTELMS.Context;
using HOTELMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly HOTELMSDbContext _dbcontext;


        public RoomController(HOTELMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        [HttpPost]

        public IActionResult Create(Room room)
        {

            _dbcontext.Rooms.Add(room);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var Rooms = _dbcontext.Rooms.ToList();
            return Ok(Rooms);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room
                = _dbcontext.Rooms.Find(id);
            return Ok(room);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var room = _dbcontext.Rooms.Find(id);
            if (room != null)
            {

                _dbcontext.Remove(room);

                _dbcontext.SaveChanges();

            }
            return Ok();


        }
        }
    }
