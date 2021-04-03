using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Dtos;
using WebApi.Domain.Interfaces.Services.User;

namespace WebApi.Application.Controllers
{
    [Route("webapi/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    

            if( loginDto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await service.FindByLogin(loginDto);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
    }
}