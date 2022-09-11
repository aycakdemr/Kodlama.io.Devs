using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Commands.DeleteFramework;
using Application.Features.Frameworks.Commands.UpdateFramework;
using Application.Features.Frameworks.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Application.Requests;
using Application.Features.Frameworks.Queries.GetListFramework;
using Application.Features.Frameworks.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateFrameworkCommand createframeworkCommand)
        {
            CreatedFrameworkDto result = await Mediator.Send(createframeworkCommand);
            return Created("", result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteFrameworkCommand deleteFrameworkCommand)
        {
            DeletedFrameworkDto result = await Mediator.Send(deleteFrameworkCommand);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFrameworkCommand updateFrameworkCommand)
        {
            UpdatedFrameworkDto result = await Mediator.Send(updateFrameworkCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFrameworkQuery getListFrameworkQuery = new() { PageRequest = pageRequest };
            FrameworkListModel result = await Mediator.Send(getListFrameworkQuery);
            return Ok(result);
        }
    }
}
