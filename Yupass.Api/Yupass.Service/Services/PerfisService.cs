using AutoMapper;
using Yupass.Domain.Dtos.Perfis;
using Yupass.Domain.Entities;
using Yupass.Domain.Interfaces;
using Yupass.Domain.Interfaces.Services.Perfis;
using Yupass.Domain.Models;

namespace Yupass.Service.Services;

public class PerfisService : IPerfisService
{
    private readonly IMapper _mapper;
    private IRepositoryBase<PerfisEntity> _perfisRepository;

    public PerfisService(IRepositoryBase<PerfisEntity> perfisRepository, IMapper mapper)
    {
        _mapper = mapper;
        _perfisRepository = perfisRepository;
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _perfisRepository.DeleteAsync(id);
    }

    public async Task<PerfilDTO?> Get(Guid id)
    {
        var entity = await _perfisRepository.SelectAsync(id);
        return _mapper.Map<PerfilDTO>(entity) ?? new PerfilDTO();
    }

    public async Task<IEnumerable<PerfilDTO>> GetAll()
    {
        var listEntity = await _perfisRepository.SelectAsync();
        return _mapper.Map<IEnumerable<PerfilDTO>>(listEntity);
    }

    public async Task<PerfilDTOCreateResult?> Post(PerfilDTOCreate perfil)
    {
        var model = _mapper.Map<PerfilModel>(perfil);
        var entity = _mapper.Map<PerfisEntity>(model);
        var result = await _perfisRepository.InsertAsync(entity);

        return _mapper.Map<PerfilDTOCreateResult>(result);
    }

    public async Task<PerfilDTOUpdateResult?> Put(PerfilDTOUpdate perfil)
    {
        var model = _mapper.Map<PerfilModel>(perfil);
        var entity = _mapper.Map<PerfisEntity>(model);
        var result = await _perfisRepository.UpdateAsync(entity);

        return _mapper.Map<PerfilDTOUpdateResult>(result);
    }
}
