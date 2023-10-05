using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;

namespace drugovich.autopecas.application.Contracts.Services;

public interface IGerenteService
{
    Task<List<GerenteViewModel>> GetAllAsync();
    Task<int> CreateAsync(CreateGerenteInputModel inputModel);
    Task<LoginViewModel> LoginAsync(string email);
}