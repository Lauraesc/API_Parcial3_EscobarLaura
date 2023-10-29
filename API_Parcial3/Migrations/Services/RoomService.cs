using API_Parcial3.DAL;
using API_Parcial3.DAL.Entities;
using API_Parcial3.Migrations.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Parcial3.Migrations.Services
{
    public class RoomService : IRoomService
    {
        public readonly DataBaseContext _context;

        public RoomService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Room> validateRoomAvailability(String number, Guid hotelId)
        {

            var room = await _context.Rooms
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(r => r.HotelId == hotelId && r.Number == number);

            return room;
    
        }
    }
}