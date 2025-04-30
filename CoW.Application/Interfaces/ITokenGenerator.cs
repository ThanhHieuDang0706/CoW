using System;

namespace CoW.Application.Interfaces;

public interface ITokenGenerator
{
    string GenerateToken(Guid userId, string email, string fullName);
}
