using CoW.Models.Auth;

namespace CoW.Application.Interfaces;
public interface IAuthService
{
    Task<AuthResponse> LoginAsync(string username, string password);
    Task<string> RegisterAsync(string username, string password);
    Task<bool> ValidateTokenAsync(string token);
}