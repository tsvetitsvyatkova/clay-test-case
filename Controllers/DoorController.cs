using System.Collections.Generic;
using ClayTest.Entities;
using ClayTest.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClayTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DoorController : ControllerBase
    {
        private readonly ILogger<DoorController> _logger;

        public DoorController(ILogger<DoorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Door>> GetAll() => DoorService.GetAll();

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Door door)
        {
            if (id != door.Id)
                return BadRequest();

            Door existingDoor = DoorService.Get(id);
            if (existingDoor is null)
                return NotFound();

            DoorService.Update(door);

            return NoContent();
        }
    }
}
