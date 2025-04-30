using CoW.Application.Exceptions;
using Cow.Models.Auth;
using CoW.Application.Interfaces;
using CoW.Models.Auth;
using Org.BouncyCastle.Crypto.Generators;


namespace CoW.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IRandomTokenGenerator _randomTokenGenerator;

        public AuthService(IUserRepository userRepository, ITokenGenerator tokenGenerator, IRandomTokenGenerator randomTokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _randomTokenGenerator = randomTokenGenerator;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedException("Invalid credentials");

            var accessToken = _tokenGenerator.GenerateToken(user.Id.ToString(), user.Email, user.FullName);
            var refreshToken = _randomTokenGenerator.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userRepository.UpdateAsync(user);

            return new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Email = user.Email,
                FullName = user.FullName
            };
        }
    }
}
