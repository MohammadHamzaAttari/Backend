using Microsoft.AspNetCore.Identity;
using Backend.Dtos.User;

namespace Backend.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto);
        Task<AuthResponseDto> Login(LoginUserDto loginApiDto);
    }
}
