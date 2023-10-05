using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.Exceptions;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using drugovich.autopecas.core;

namespace drugovich.autopecas.application.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IGrupoRepository _grupoRepository;
    private readonly IMapper _mapper;

    public ClienteService(
        IClienteRepository clienteRepository, 
        IGrupoRepository grupoRepository,
        IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
        _grupoRepository = grupoRepository;
    }

    public async Task<List<ClienteViewModel>> GetAllAsync(string query)
    {
        var clientes = await _clienteRepository.GetAllClientesWithGruposAsync(query);

        var clientesVm = _mapper.Map<List<ClienteViewModel>>(clientes);
        return clientesVm;
    }

    public async Task<ClienteViewModel> GetByIdAsync(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdWIthGrupoAsync(id);

        var clienteVm = _mapper.Map<ClienteViewModel>(cliente);
        return clienteVm;
    }

    public async Task<int> CreateAsync(CreateClienteInputModel inputModel)
    {
        await CheckIfGroupExists(inputModel.GrupoId);

        var cliente = _mapper.Map<Cliente>(inputModel);

        await _clienteRepository.CreateAsync(cliente);

        return cliente.Id;
    }

    public async Task UpdateAsync(UpdateClienteInputModel inputModel)
    {
        await CheckIfGroupExists(inputModel.GrupoId);
        
        var cliente = await _clienteRepository.GetByIdAsync(inputModel.Id);
        if (cliente != null)
        {
            cliente.Nome = inputModel.Nome;
            cliente.GrupoId = inputModel.GrupoId;
            await _clienteRepository.UpdateAsync(cliente);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente != null)
        {
            await _clienteRepository.DeleteAsync(cliente);
        }
    }
    
    public async Task CheckIfGroupExists(int id)
    {
        var grupo = await _grupoRepository.GetByIdAsync(id);
        if (grupo is null)
        {
            throw new NotFoundException(nameof(Grupo), id);
        }
    }
}