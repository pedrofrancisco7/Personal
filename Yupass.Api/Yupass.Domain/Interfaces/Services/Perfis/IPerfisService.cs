using Yupass.Domain.Dtos.Perfis;

namespace Yupass.Domain.Interfaces.Services.Perfis;

public interface IPerfisService
{
    Task<PerfilDTO?> Get(Guid id);
    Task<IEnumerable<PerfilDTO>> GetAll();
    Task<PerfilDTOCreateResult?> Post(PerfilDTOCreate perfil);
    Task<PerfilDTOUpdateResult?> Put(PerfilDTOUpdate perfil);
    Task<bool> Delete(Guid id);
}
