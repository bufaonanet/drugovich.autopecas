using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using drugovich.autopecas.core;

namespace drugovich.autopecas.application.Services;

public class GrupoService : IGrupoService
{
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public GrupoService(IGrupoRepository grupoRepository, IMapper mapper)
    {
        _grupoRepository = grupoRepository;
        _mapper = mapper;
    }

    public async Task<List<GrupoViewModel>> GetAllAsync(string query)
    {
        var grupos = await _grupoRepository.GetAllAsync(query);

        var gruposVm = _mapper.Map<List<GrupoViewModel>>(grupos);
        return gruposVm;
    }

    public async Task<GrupoViewModel> GetByIdAsync(int id)
    {
        var grupo = await _grupoRepository.GetByIdAsync(id);

        var grupoVm = _mapper.Map<GrupoViewModel>(grupo);
        return grupoVm;
    }

    public async Task<int> CreateAsync(CreateGrupoInputModel inputModel)
    {
        var grupo = _mapper.Map<Grupo>(inputModel);

        await _grupoRepository.CreateAsync(grupo);

        return grupo.Id;
    }

    public async Task UpdateAsync(UpdateGrupoInputModel inputModel)
    {
        var grupo = await _grupoRepository.GetByIdAsync(inputModel.Id);
        if (grupo != null)
        {
            grupo.Nome = inputModel.Nome;
            await _grupoRepository.UpdateAsync(grupo);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var grupo = await _grupoRepository.GetByIdAsync(id);
        if (grupo != null)
        {
            await _grupoRepository.DeleteAsync(grupo);
        }
    }
}