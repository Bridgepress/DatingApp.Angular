using API.DTOs;
using API.Entities;
using API.Helpers;
using DatingApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.Domain.Interfaces
{
    public interface ILikeService
    {
        Task AddLike(string username);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}
