
using Experion.Marina.Dto;

namespace Experion.Marina.Business.Services.Contracts
{
    public interface ILoginService
    {
        UserDto Login(UserLoginDto user);
    }
}
