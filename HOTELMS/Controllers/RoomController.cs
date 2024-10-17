using HOTELMS.Context;
using HOTELMS.DTOS;
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

        public IActionResult Create(RoomDto roomDto)
        {
            var room = new Room();
            room.Id = roomDto.Id;
            room.RoomNumbers = roomDto.RoomNumbers;
            room.Description = roomDto.Description;
            room.HotelId = roomDto.HotelId;
            room.Floor=roomDto.Floor;

            _dbcontext.Rooms.Add(room);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var dtos = new List<RoomDto>();
            var Rooms = _dbcontext.Rooms.ToList();
            foreach (var room in Rooms)
            {

                var roomDto = new RoomDto();

                roomDto.Id = room.Id;
                roomDto.Floor =room.Floor;
                roomDto.Description = room.Description;
                roomDto.HotelId = room.HotelId;
                roomDto.RoomNumbers = room.RoomNumbers;
                dtos.Add(roomDto);

            }
            return Ok(dtos);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var room
                = _dbcontext.Rooms.Find(id);
            var roomDto = new RoomDto();

            roomDto.Id = room.Id;
            roomDto.Floor = room.Floor;
            roomDto.Description = room.Description;
            roomDto.HotelId = room.HotelId;
            roomDto.RoomNumbers = room.RoomNumbers;


            return Ok(roomDto);
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
