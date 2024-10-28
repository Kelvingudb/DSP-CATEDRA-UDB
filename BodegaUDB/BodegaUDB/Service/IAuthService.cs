using BodegaUDB.Dtos;

namespace BodegaUDB.Service
{
    public interface IAuthService
    {
        Task<string> AuthenticateUser(UserLoginDto userLoginDto);

    }
}
