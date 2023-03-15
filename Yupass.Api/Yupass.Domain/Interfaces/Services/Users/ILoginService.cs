using Yupass.Domain.Dtos;
using Yupass.Domain.Dtos.Usuarios;

namespace Yupass.Domain.Interfaces.Services.Users;

public interface ILoginService
{
    Task<object?> FindByLogin(LoginDTO usuario);
    Task<UsuarioDTO> FindByLogin(string login);
    Task<int> UpdateTemporaryAccess(UsuarioDTO usuario);
}
