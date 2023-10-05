namespace drugovich.autopecas.application.Contracts.Services;

public interface IAuthService
{
    string GenerateJwtToken(string email, string nivelAcesso);
}