using AutoMapper;
using Yupass.Domain.Dtos.Usuarios;
using Yupass.Domain.Entities;
using Yupass.Domain.Interfaces;
using Yupass.Domain.Interfaces.Services;
using Yupass.Domain.Interfaces.Services.Users;
using Yupass.Domain.Models;

namespace Yupass.Application.Services;

public class UsuariosService : IUsuariosService
{
    private readonly IMapper _mapper;
    private IRepositoryBase<UsuariosEntity> _usersRepository;

    public UsuariosService(IRepositoryBase<UsuariosEntity> usersRepository, IMapper mapper)
    {
        _mapper = mapper;
        _usersRepository = usersRepository;
    }
    public async Task<bool> Delete(Guid id)
    {
        return await _usersRepository.DeleteAsync(id);
    }

    public async Task<UsuarioDTO?> Get(Guid id)
    {
        var entity = await _usersRepository.SelectAsync(id);
        return _mapper.Map<UsuarioDTO>(entity) ?? new UsuarioDTO();
    }

    public async Task<IEnumerable<UsuarioDTO>> GetAll()
    {
        var listEntity = await _usersRepository.SelectAsync();
        return _mapper.Map<IEnumerable<UsuarioDTO>>(listEntity);

    }

    public async Task<UsuarioDTOCreateResult?> Post(UsuarioDTOCreate user)
    {
        var model = _mapper.Map<UsuarioModel>(user);
        var entity = _mapper.Map<UsuariosEntity>(model);
        var result = await _usersRepository.InsertAsync(entity);

        return _mapper.Map<UsuarioDTOCreateResult>(result);
    }

    public async Task<UsuarioDTOUpdateResult?> Put(UsuarioDTOUpdate user)
    {
        var model = _mapper.Map<UsuarioModel>(user);
        var entity = _mapper.Map<UsuariosEntity>(model);
        var result = await _usersRepository.UpdateAsync(entity);

        return _mapper.Map<UsuarioDTOUpdateResult>(result);
    }
}
