using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Yupass.Domain.Dtos;
using Yupass.Domain.Dtos.Usuarios;
using Yupass.Domain.Interfaces.Services.Users;

namespace Yupass.Application.Controllers;

[Route("api/[controller]")]

[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;
    private readonly IUsuariosService _usuariosService;

    public LoginController(ILoginService loginService, IUsuariosService usuariosService)
    {
        _loginService = loginService;
        _usuariosService = usuariosService;
    }


    [HttpPost]
    [AllowAnonymous]
    public async Task<object> Login([FromBody] LoginDTO usuario)
    {      

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (usuario == null)
        {
            return BadRequest();
        }

        try
        {
            var result = await _loginService.FindByLogin(usuario);
            if (result != null)
            {
                //var acessoTemporario = result.GetType().GetProperty("acessoTemporario")?.GetValue(result);

                //if ((bool)acessoTemporario)
                //{
                var usuarioAcesso = await _loginService.FindByLogin(usuario.Login);

                //    var userUpd = new UsuarioDTOUpdate {
                //        Id = usuarioAcesso.Id,
                //        Cpf = usuarioAcesso.Cpf,
                //        Nome = usuarioAcesso.Nome,
                //        Senha = usuarioAcesso.Senha,
                //        AcessoTemporario = false                        
                //    };

                //    _usuariosService.Put(userUpd);

                //}

                return Ok(result);
            }
            else
            {
                return NotFound();
            }


        }
        catch (ArgumentException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
