using Domain.Entites;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (userEntity == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await service.FindByLogin(userEntity);
                if (result != null) {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (ArgumentException error)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, error.Message);
            }
        }
    }
}
