using API_Parcial3.DAL.Entities;
using System.Diagnostics.Metrics;

namespace API_Parcial3.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {

            await _context.Database.EnsureCreatedAsync();

         
            await PopulateHotelsAsync();

            await _context.SaveChangesAsync(); 
        }

        #region Private Methods
        private async Task PopulateHotelsAsync()
        {

            if (!_context.Hotels.Any())
            {
     
                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Hilton House",
                    Address = "CLL 53 No 10-60/46",
                    City = "Bogotá",
                    Phone = "4063296",
                    Stars = 3,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "101",
                            MaxGuests = 5,
                            Availability = true
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "102",
                            MaxGuests = 2,
                            Availability = true
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "103",
                            MaxGuests = 4,
                            Availability = false
                        }
                    }
                });

             
                _context.Hotels.Add(new Hotel
                {
                    CreatedDate = DateTime.Now,
                    Name = "Anthony's Garden",
                    Address = "CR 21 # 17 - 63",
                    City = "Medellín",
                    Phone = null,
                    Stars = 5,
                    Rooms = new List<Room>()
                    {
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "101",
                            MaxGuests = 2,
                            Availability = false
                        },

                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "102",
                            MaxGuests = 1,
                            Availability = true
                        },
                        new Room
                        {
                            CreatedDate = DateTime.Now,
                            Number = "103",
                            MaxGuests = 4,
                            Availability = false
                        }
                    }
                });
            }
        }
        #endregion
    }


}

