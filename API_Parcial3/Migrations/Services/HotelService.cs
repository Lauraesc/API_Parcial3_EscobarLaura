using API_Parcial3.DAL;
using API_Parcial3.DAL.Entities;
using API_Parcial3.Migrations.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace API_Parcial3.Migrations.Services
{
    public class HotelService : IHotelService
    {
        public readonly DataBaseContext _context;

        public HotelService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsAsync()
        {

            return await _context.Hotels
        .Include(h => h.Rooms.Where(r => r.Availability == true))
        .ToListAsync();

        }

        public async Task<Hotel> GetHotelByIdAsync(Guid id)
        {
            return await _context.Hotels
        .Include(h => h.Rooms.Where(r => r.Availability == true))
        .FirstOrDefaultAsync(h => h.Id == id);

        }

        public async Task<Hotel> GetHotelByCityAsync(String city)
        {
            return await _context.Hotels
        .Include(h => h.Rooms.Where(r => r.Availability == true))
        .FirstOrDefaultAsync(h => h.City == city);

        }

        public async Task<Hotel> EditHotelStarsAsync(Guid id, int newStars)
        {
            try
            {

                var hotel = await _context.Hotels.FindAsync(id);

                if (hotel != null)
                {
                    hotel.Stars = newStars;
                    hotel.ModifiedDate = DateTime.Now;

                    _context.Hotels.Update(hotel);
                    await _context.SaveChangesAsync();
                }

                return hotel;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Hotel> DeleteHotelAsync(Guid id)
        {
            try
            {

                var hotel = await _context.Hotels.Include(h => h.Rooms).FirstOrDefaultAsync(h => h.Id == id);
                if (hotel == null) return null;

                //delete asociated rooms
                _context.Rooms.RemoveRange(hotel.Rooms);

                //delete the hotel
                _context.Hotels.Remove(hotel);

                await _context.SaveChangesAsync();

                return hotel;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);

            }
            
            

        }
    }
}
