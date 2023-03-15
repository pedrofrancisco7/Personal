using Yupass.Domain.Dtos.Usuarios;

namespace Yupass.Domain.Interfaces.Services.Users;

public interface IUsuariosService
{
    Task<UsuarioDTO?> Get(Guid id);
    Task<IEnumerable<UsuarioDTO>> GetAll();
    Task<UsuarioDTOCreateResult?> Post(UsuarioDTOCreate user);
    Task<UsuarioDTOUpdateResult?> Put(UsuarioDTOUpdate user);
    Task<bool> Delete(Guid id);    
}
