using API_Parcial3.DAL.Entities;
using System.Diagnostics.Metrics;

namespace API_Parcial3.Domain.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<Hotel> GetHotelByCityAsync(String city);
        Task<Hotel> EditHotelStarsAsync(Guid id, int newStars);
        Task<Hotel> DeleteHotelAsync(Guid id);



    }
}
