using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Yupass.Data.Crypto;
using Yupass.Data.Repository;
using Yupass.Domain.Dtos;
using Yupass.Domain.Dtos.Usuarios;
using Yupass.Domain.Entities;
using Yupass.Domain.Interfaces.Services.Users;
using Yupass.Domain.Repository;
using Yupass.Domain.Security;

namespace Yupass.Service.Services;

public class LoginService : ILoginService
{
    private readonly IUsuarioRepository _usuariosRepository;
    private readonly IMapper _mapper;
    public SigningConfiguration _signingConfiguration;
    public TokenConfiguration _tokenConfiguration;
    private IConfiguration _configuration { get; }

    public LoginService(IUsuarioRepository usuarioRepository,
                        IMapper mapper,
                        IConfiguration configuration,
                        SigningConfiguration signingConfiguration,
                        TokenConfiguration tokenConfiguration)
    {
        _usuariosRepository = usuarioRepository;
        _configuration = configuration;
        _signingConfiguration = signingConfiguration;
        _tokenConfiguration = tokenConfiguration;
        _mapper = mapper;
    }

    public async Task<object?> FindByLogin(LoginDTO usuario)
    {
        if (usuario != null && (!string.IsNullOrWhiteSpace(usuario.Login) && !string.IsNullOrWhiteSpace(usuario.Senha)))
        {
            var senha = BaseCrypto.EncryptSha256(usuario.Senha);

            UsuariosEntity? baseUser = await _usuariosRepository.FindByLogin(usuario.Login, senha);
            if (baseUser == null)
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
            else
            {
                var identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Login), new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Login.ToString()),

                    });

                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                var handle = new JwtSecurityTokenHandler();
                var token = CreateToken(identity, createDate, expirationDate, handle);

                return SuccessObject(createDate, expirationDate, token, usuario, baseUser.AcessoTemporario);
            }
        }
        else
        {
            return null;
        }
    }

    private string CreateToken(ClaimsIdentity identity,DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handle)
    {
        var securityToken = handle.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _tokenConfiguration.Issuer,
            Audience = _tokenConfiguration.Audience,
            SigningCredentials = _signingConfiguration.SigningCredentials,
            Subject = identity,
            NotBefore = createDate,
            Expires = expirationDate
        });

        var token = handle.WriteToken(securityToken);
        return token;
    }

    private static object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDTO usuario, bool acessoTemporario)
    {
        return new
        {
            authenticated = true,
            created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
            expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
            acessToken = token,
            userName = usuario.Login,
            message = "Usuário logado com sucesso",
            acessoTemporario = acessoTemporario
        };
    }

    public async Task<UsuarioDTO> FindByLogin(string login)
    {
        var entity = await _usuariosRepository.FindByLogin(login);
        return _mapper.Map<UsuarioDTO>(entity) ?? new UsuarioDTO();
    }

    public async Task<int> UpdateTemporaryAccess(UsuarioDTO usuario)
    {
        var usuarioEntity = await _usuariosRepository.FindByLogin(usuario.Cpf);
        var updUsuario = _usuariosRepository.UpdateTemporaryAccess(usuarioEntity);
        return 1;
    }
}
