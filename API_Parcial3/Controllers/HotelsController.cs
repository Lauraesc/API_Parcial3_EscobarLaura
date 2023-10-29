using API_Parcial3.DAL.Entities;
using API_Parcial3.Migrations.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;


namespace API_Parcial3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : Controller 
    {
        private readonly IHotelService _hotelService;
    
        public HotelsController(IHotelService countryService)
        {
            _hotelService = countryService;
        }

        [HttpGet, ActionName("Get")] //DataNotation
        [Route("GetAll")] 
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelsAsync()
        {
            
            var hotels = await _hotelService.GetHotelsAsync();  

            if (hotels == null || !hotels.Any()) 
            {
                return NotFound(); 
            }

            
            return Ok(hotels);  
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] //URL: api/countries/get
        public async Task<ActionResult<Hotel>> GetHotelByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("The Id is required!");

            var hotel = await _hotelService.GetHotelByIdAsync(id);

            if (hotel == null) return NotFound(); // 404

            return Ok(hotel); // 200
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByCity/{city}")] //URL: 
        public async Task<ActionResult<Hotel>> GetHotelByCityAsync(String city)
        {
            if (city == null) return BadRequest("The city is required!");

            var hotel = await _hotelService.GetHotelByCityAsync(city);

            if (hotel == null) return NotFound(); // 404

            return Ok(hotel); // 200
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Hotel>> EditHotelStarsAsync(Guid id, int newStars)
        {

            var editedHotel = await _hotelService.EditHotelStarsAsync(id, newStars);

            return Ok(editedHotel);

        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Hotel>> DeleteHotelAsync(Guid id)
        {
            if (id == null) return BadRequest("Id is required!");

            var deletedHotel = await _hotelService.DeleteHotelAsync(id);

            if (deletedHotel == null) return NotFound("Hotel not found!");

            return Ok(deletedHotel);
        }
    }
}