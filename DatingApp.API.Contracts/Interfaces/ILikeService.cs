using API.DTOs;
using API.Helpers;

namespace DatingApp.Domain.Interfaces
{
	public interface ILikeService
	{
		Task AddLike(string username);
		Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
	}
}
