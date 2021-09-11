using Microsoft.AspNetCore.Mvc;
using System;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {

        }

        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("Inbound POST # Commnad Service");
            return Ok("Inbound test from Command Service # Platforms Controller");
        }
    }
}