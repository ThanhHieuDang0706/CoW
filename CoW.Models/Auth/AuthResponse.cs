using System;

namespace CoW.Models.Auth;

public struct AuthResponse
{
    public AuthResponse()
    {
    }

    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
}
