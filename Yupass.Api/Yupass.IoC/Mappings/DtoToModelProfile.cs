using AutoMapper;
using Yupass.Domain.Dtos.Perfis;
using Yupass.Domain.Dtos.Usuarios;
using Yupass.Domain.Models;

namespace Yupass.IoC.Mappings;

public class DtoToModelProfile : Profile
{
    public DtoToModelProfile()
    {
        #region Usuario
        
        CreateMap<UsuarioModel, UsuarioDTO>()
                 .ReverseMap();

        CreateMap<UsuarioModel, UsuarioDTOCreate>()
                 .ReverseMap();

        CreateMap<UsuarioModel, UsuarioDTOUpdate>()
                 .ReverseMap();
        #endregion

        #region Perfil
        CreateMap<PerfilModel, PerfilDTO>()
         .ReverseMap();

        CreateMap<PerfilModel, PerfilDTOCreate>()
                 .ReverseMap();

        CreateMap<PerfilModel, PerfilDTOUpdate>()
                 .ReverseMap();
        #endregion

    }
}
