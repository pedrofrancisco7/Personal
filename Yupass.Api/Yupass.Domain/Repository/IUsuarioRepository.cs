using Yupass.Domain.Entities;
using Yupass.Domain.Interfaces;

namespace Yupass.Domain.Repository;

public interface IUsuarioRepository : IRepositoryBase<UsuariosEntity>
{
    Task<UsuariosEntity?> FindByLogin(string cpf, string senha);
    Task<UsuariosEntity?> FindByLogin(string login);
    Task<UsuariosEntity?> UpdateTemporaryAccess(UsuariosEntity login);
}
