namespace StudentAttendanceTrackingApp.Business.TokenValidation.Abstract
{
    public interface ITokenValidationService
    {
        bool ValidateToken(string token);
    }
}