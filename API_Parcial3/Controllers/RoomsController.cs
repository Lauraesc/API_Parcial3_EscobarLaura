using API_Parcial3.DAL.Entities;
using API_Parcial3.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Parcial3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _roomService;
        //para conectarme a la interfaz necesito esta dependencia a la interfaz
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByNumberId/")] 
        public async Task<ActionResult<Room>> validateRoomAvailability(String number, Guid hotelId)
        {
            var room = await _roomService.validateRoomAvailability(number, hotelId);

            if (number == null) return BadRequest("number is required!");
            if (hotelId == null) return BadRequest("hotelId is required!");

            if (room == null) return NotFound($"Room {number} not found.");
            if (!room.Availability) return BadRequest($"Room {number} of the hotel {room.Hotel.Name} already booked.");
            
            return Ok(room);

        }
    }
}
