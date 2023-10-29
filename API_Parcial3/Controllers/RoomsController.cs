using API_Parcial3.Migrations.Interfaces;
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
    }
}
