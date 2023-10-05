using drugovich.autopecas.application.InputModels;
using drugovich.autopecas.application.ViewModels;

namespace drugovich.autopecas.application.Contracts.Services;

public interface IGrupoService
{
    Task<List<GrupoViewModel>> GetAllAsync(string query);

    Task<GrupoViewModel> GetByIdAsync(int id);

    Task<int> CreateAsync(CreateGrupoInputModel inputModel);

    Task UpdateAsync(UpdateGrupoInputModel inputModel);

    Task DeleteAsync(int id);
}