using AutoMapper;
using Yupass.Domain.Entities;
using Yupass.Domain.Models;

namespace Yupass.IoC.Mappings;

public class ModelToEntityProfile : Profile
{
    public ModelToEntityProfile()
    {
        #region Usuario
        CreateMap<UsuariosEntity, UsuarioModel>()
            .ReverseMap();
        #endregion

        #region Perfil
        CreateMap<PerfisEntity, PerfilModel>()
            .ReverseMap();
        #endregion

    }
}
