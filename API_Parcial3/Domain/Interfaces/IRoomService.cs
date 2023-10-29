using API_Parcial3.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace API_Parcial3.Domain.Interfaces
{
    public interface IRoomService
    {
        Task<Room> validateRoomAvailability(string number, Guid hotelId);
    }
}
