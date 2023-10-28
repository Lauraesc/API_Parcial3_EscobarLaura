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
            //Primero: agregaré un método propio de EF que hace las veces del comando 'update-database'
            //En otras palabras: un método que me creará la BD inmediatamente ponga en ejecución mi API
            await _context.Database.EnsureCreatedAsync();

            //A partir de aquí vamos a ir creando métodos que me sirvan para prepoblar mi BD
            await PopulateHotelsAsync();

            await _context.SaveChangesAsync(); //Esta línea me guarda ls datos en BD
        }

        #region Private Methods
        private async Task PopulateHotelsAsync()
        {
            //El método Any() me indica si la tabla Countries tiene al menos un registro
            //El método Any negado (!) me indica que no hay absolutamente nada en la tabla Countries.

            if (!_context.Hotels.Any())
            {
                //Así creo yo un objeto país con sus respectivos estados
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

                //Aquí creo otro nuevo país
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

