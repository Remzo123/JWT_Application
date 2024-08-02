using JWT_Application.DTO;

namespace JWT_Application.Implementetion.Jwt_Web_Token
{
    public interface IJWTService
    {
        string JwtWebToken(BookingDto request);
    }
}
