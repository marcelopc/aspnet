using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService serice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok( await serice.GetAll());
            }
            catch (ArgumentException error)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, error.Message);
            }
        }

    }
}
