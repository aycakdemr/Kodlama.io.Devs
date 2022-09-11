using Application.Features.Socials.Commands.CreateSocial;
using Application.Features.Socials.Commands.DeleteSocial;
using Application.Features.Socials.Commands.UpdateSocial;
using Application.Features.Socials.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateSocialCommand createSocialCommand)
        {
            CreatedSocialDto result = await Mediator.Send(createSocialCommand);
            return Created("", result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSocialCommand deleteSocialCommand)
        {
            DeletedSocialDto result = await Mediator.Send(deleteSocialCommand);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateSocialCommand updateSocialCommand)
        {
            UpdatedSocialDto result = await Mediator.Send(updateSocialCommand);
            return Ok(result);
        }
    }
}
