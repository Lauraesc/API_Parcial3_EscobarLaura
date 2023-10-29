using API_Parcial3.DAL;
using API_Parcial3.Migrations.Interfaces;

namespace API_Parcial3.Migrations.Services
{
    public class RoomService : IRoomService
    {
        public readonly DataBaseContext _context;

        public RoomService(DataBaseContext context)
        {
            _context = context;
        }
    }
}
