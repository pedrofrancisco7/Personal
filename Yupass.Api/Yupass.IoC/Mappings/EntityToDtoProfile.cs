using AutoMapper;
using Yupass.Domain.Dtos.Perfis;
using Yupass.Domain.Dtos.Usuarios;
using Yupass.Domain.Entities;

namespace Yupass.IoC.Mappings;

public class EntityToDtoProfile : Profile
{
    public EntityToDtoProfile()
    {
        #region Usuario
        CreateMap<UsuarioDTO, UsuariosEntity>()
            .ReverseMap();

        CreateMap<UsuarioDTOCreateResult, UsuariosEntity>()
            .ReverseMap();

        CreateMap<UsuarioDTOUpdateResult, UsuariosEntity>()
            .ReverseMap();
        #endregion

        #region Perfil
        CreateMap<PerfilDTO, PerfisEntity>()
            .ReverseMap();

        CreateMap<PerfilDTOCreateResult, PerfisEntity>()
            .ReverseMap();

        CreateMap<PerfilDTOUpdateResult, PerfisEntity>()
            .ReverseMap();
        #endregion
    }
}
