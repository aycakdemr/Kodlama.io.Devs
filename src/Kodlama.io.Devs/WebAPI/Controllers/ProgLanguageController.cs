using Application.Features.ProgLanguages.Commands.CreateProgLanguage;
using Application.Features.ProgLanguages.Commands.DeleteProgLanguage;
using Application.Features.ProgLanguages.Commands.UpdateProgLanguage;
using Application.Features.ProgLanguages.Dtos;
using Application.Features.ProgLanguages.Models;
using Application.Features.ProgLanguages.Queries.GetByIdProgLanguage;
using Application.Features.ProgLanguages.Queries.GetListProgLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgLanguageController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgLanguageCommand createProgLanguageCommand)
        {
            CreatedProgLanguageDto result = await Mediator.Send(createProgLanguageCommand);
            return Created("", result);
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgLanguageCommand deleteProgLanguageCommand)
        {
            DeletedProgLanguageDto result = await Mediator.Send(deleteProgLanguageCommand);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgLanguageCommand updateProgLanguageCommand)
        {
            UpdatedProgLanguageDto result = await Mediator.Send(updateProgLanguageCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgLanguageQuery getListProgLanguageQuery = new() { PageRequest = pageRequest };
            ProgLanguageListModel result = await Mediator.Send(getListProgLanguageQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgLanguageQuery getByIdProgLanguageQuery)
        {
            ProgLanguageGetByIdDto result = await Mediator.Send(getByIdProgLanguageQuery);
            return Ok(result);
        }
    }

}
