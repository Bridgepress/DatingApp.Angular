using API.DTOs;

namespace DatingApp.Domain.Interfaces
{
	public interface IAccountService
	{
		Task<UserDto> Register(RegisterDto registerDto);
		Task<UserDto> Login(LoginDto loginDto);
		Task<bool> UserExists(string userName);

	}
}
