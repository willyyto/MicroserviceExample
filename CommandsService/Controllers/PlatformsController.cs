using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("--> Inbound POST command service");
            return Ok("Inbound test okay from platforms controller");
        }
    }
}