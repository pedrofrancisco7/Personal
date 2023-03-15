using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yupass.Domain.Dtos.Usuarios;
using Yupass.Domain.Entities;
using Yupass.Domain.Interfaces.Services.Users;

namespace Yupass.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosService _usersService;
    public UsuariosController(IUsuariosService usersService)
    {
        _usersService = usersService;
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
            return Ok(await _usersService.GetAll());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpGet]
    //[Authorize("Bearer")]
    [Route("{id}", Name = "GetById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(await _usersService.Get(id));
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }

    [HttpPost]
    //[Authorize("Bearer")]
    public async Task<IActionResult> Post([FromBody] UsuarioDTOCreate user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _usersService.Post(user);
            if (result != null)
            {
                return Created(new Uri(uriString: Url.Link("GetById", new { id = result.Id })), result);
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
    public async Task<IActionResult> Put([FromBody] UsuarioDTOUpdate user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var result = await _usersService.Put(user);
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
            return Ok(await _usersService.Delete(id));
        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }
}
