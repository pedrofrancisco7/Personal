using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yupass.Domain.Dtos.Perfis;
using Yupass.Domain.Interfaces.Services.Perfis;

namespace Yupass.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerfisController : Controller
{
    private readonly IPerfisService _perfilService;
    public PerfisController(IPerfisService perfilService)
    {
        _perfilService = perfilService; 
    }

    [HttpGet]
    //[Authorize("Bearer")]
    public async Task<IActionResult> GetAll()
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _perfilService.GetAll());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpGet]
    //[Authorize("Bearer")]
    [Route("{id}", Name = "GetProfileById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _perfilService.Get(id));
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpPost]
    //[Authorize("Bearer")]
    public async Task<IActionResult> Post([FromBody] PerfilDTOCreate user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _perfilService.Post(user);
            if (result != null)
            {
                return Created(new Uri(uriString: Url.Link("GetProfileById", new { id = result.Id })), result);
            }
            else
            {
                return BadRequest();
            }


        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpPut]
    //[Authorize("Bearer")]
    public async Task<IActionResult> Put([FromBody] PerfilDTOUpdate user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _perfilService.Put(user);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }


        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpDelete("{id}")]
    //[Authorize("Bearer")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _perfilService.Delete(id));
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

}
