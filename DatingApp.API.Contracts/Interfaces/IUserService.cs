using API.DTOs;
using API.Helpers;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Domain.Interfaces
{
	public interface IUserService
	{
		Task<PagedList<MemberDto>> GetUsers(UserParams userParams);
		Task<MemberDto> GetUser(string username);
		Task UpdateUser(MemberUpdateDto memberUpdateDto);
		Task<PhotoDto> AddPhoto(IFormFile file);
		Task SetMainPhoto(int photoId);
		Task DeletePhoto(int photoId);
	}
}
