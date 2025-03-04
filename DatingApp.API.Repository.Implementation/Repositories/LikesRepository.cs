﻿using API.DTOs;
using API.Entities;
using API.Helpers;
using DatingApp.Contracts.Repositories;
using DatingApp.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class LikesRepository : ILikesRepository
	{
		private readonly DataContext _context;

		public LikesRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<UserLike> GetUserLike(int sourceUserId, int targetUserId)
		{
			return await _context.Likes.FindAsync(sourceUserId, targetUserId);
		}

		public async Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams)
		{
			var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
			var likes = _context.Likes.AsQueryable();
			if (likesParams.Predicate == "liked")
			{
				likes = likes.Where(l => l.SourceUserId == likesParams.UserId);
				users = likes.Select(l => l.TargetUser);
			}
			if (likesParams.Predicate == "likedBy")
			{
				likes = likes.Where(l => l.TargetUserId == likesParams.UserId);
				users = likes.Select(l => l.SourceUser);
			}
			var likedUsers = users.Select(user => new LikeDto
			{
				Username = user.UserName,
				KnowAs = user.KnowAs,
				Age = user.DateOfBirth.CalculateAge(),
				PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain).Url,
				City = user.City,
				Id = user.Id
			});
			return await PagedList<LikeDto>.CreateAsync(likedUsers, likesParams.PageNumber, likesParams.PageSize);
		}

		public async Task<AppUser> GetUserWithLikes(int userId)
		{
			return await _context.Users
				.Include(x => x.LikedUsers)
				.FirstOrDefaultAsync(x => x.Id == userId);
		}
	}
}
