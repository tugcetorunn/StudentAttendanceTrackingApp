
namespace StudentAttendanceTrackingApp.Business.TokenValidation.Concrete
{
    public class TokenValidationService : ITokenValidationService
    {
        private readonly TokenService tokenService;

        public TokenValidationService(TokenService _tokenService)
        {
            tokenService = _tokenService;
        }

        public bool ValidateToken(string token)
        {
            return tokenService.IsValidToken(token);
        }
    }
}
