using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;

namespace drugovich.autopecas.application.Contracts.Services;

public interface IClienteService
{
    Task<List<ClienteViewModel>> GetAllAsync(string query);

    Task<ClienteViewModel> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateClienteInputModel inputModel);

    Task UpdateAsync(UpdateClienteInputModel inputModel);

    Task DeleteAsync(int id);
}