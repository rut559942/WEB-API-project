using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entity;
using Service;


namespace MyWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private readonly IUpdateService _service;

        public UpdateController(IUpdateService service)
        {
            _service = service;
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
           bool? u = await _service.Update(user);
            if (u == null)
                return BadRequest();
            if (u==true)
                return NoContent();
            return NotFound();
        }
    }
}
