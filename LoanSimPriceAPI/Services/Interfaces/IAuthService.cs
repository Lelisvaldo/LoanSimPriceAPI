namespace LoanSimPriceAPI.Services.Interfaces;

public interface IAuthService
{
    string GenerateJwtToken(string username);
}