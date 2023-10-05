using AutoMapper;
using drugovich.autopecas.application.Contracts.Repositories;
using drugovich.autopecas.application.Contracts.Services;
using drugovich.autopecas.application.Exceptions;
using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;
using drugovich.autopecas.core;
using drugovich.autopecas.core.Extensions;

namespace drugovich.autopecas.application.Services;

public class GerenteService : IGerenteService
{
    private readonly IAuthService _authService;
    private readonly IGerenteRepository _gerenteRepository;
    private readonly IMapper _mapper;

    public GerenteService(
        IAuthService authService,
        IGerenteRepository gerenteRepository,
        IMapper mapper)
    {
        _authService = authService;
        _gerenteRepository = gerenteRepository;
        _mapper = mapper;
    }

    public async Task<List<GerenteViewModel>> GetAllAsync()
    {
        var gerentes = await _gerenteRepository.GetAllAsync();

        var gerentesVm = _mapper.Map<List<GerenteViewModel>>(gerentes);
        return gerentesVm;
    }

    public async Task<int> CreateAsync(CreateGerenteInputModel inputModel)
    {
        var gerente = await _gerenteRepository.GetClienteByEmailAsync(inputModel.Email);
        if (gerente is not null)
        {
            throw new DomainException($"Já existe um Gerente cadastrado com o email: {inputModel.Email} ");
        }

        var gerenteNovo = _mapper.Map<Gerente>(inputModel);

        await _gerenteRepository.CreateAsync(gerenteNovo);

        return gerenteNovo.Id;
    }

    public async Task<LoginViewModel> LoginAsync(string email)
    {
        var gerente = await _gerenteRepository.GetClienteByEmailAsync(email);
        if (gerente is null)
        {
            return new LoginViewModel
            {
                Sucesso = false,
                Token = ""
            };
        }

        var token = _authService.GenerateJwtToken(gerente.Email, gerente.Nivel.GetDescription());

        return new LoginViewModel
        {
            Sucesso = true,
            Token = token
        };
    }
}