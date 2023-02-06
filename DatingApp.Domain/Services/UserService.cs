using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using DatingApp.Contracts.Repositories;
using DatingApp.Domain.Exceptions.InfrastructureExceptions;
using DatingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DatingApp.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IPhotoService _photoService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, IPhotoService photoService, ILogger<UserService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _photoService = photoService;
        }

        public async Task<PhotoDto> AddPhoto(IFormFile file)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(_httpContextAccessor.HttpContext.User.GetUserName());
            var result = await _photoService.AddPhotoAsync(file);
            if (result.Error != null)
            {
                _logger.LogError("No photo added {Type}", typeof(IFormFile));
                return null;
            }
            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            user.Photos.Add(photo);
            if (await _unitOfWork.Complete())
            {
                _logger.LogInformation("Photo Added", typeof(IFormFile));
                return _mapper.Map<PhotoDto>(photo);
            }
            _logger.LogError("Problem addding photo {Type}", typeof(IFormFile));
            return null;
        }

        public async Task DeletePhoto(int photoId)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(_httpContextAccessor.HttpContext.User.GetUserName());
            var photo = await _unitOfWork.PhotoRepository.GetPhotoById(photoId);
            if (photo == null)
            {
                throw new InfrastructureExceptions(HttpStatusCode.NotFound);
            }
            if (photo.IsMain)
            {
                _logger.LogInformation("You cannot delete your main photo");
            }
            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null)
                {
                    _logger.LogError("You cannot delete your main photo {message}", result.Error.Message);
                }
            }
            user.Photos.Remove(photo);
            if (await _unitOfWork.Complete())
            {
                _logger.LogInformation("Photo Added {photo}", photo.Url);
            }
            else
            {
                _logger.LogError("Failed to delete the photo", photo.Url);
            }
        }

        public async Task<MemberDto> GetUser(string username)
        {
            var currentUsername = _httpContextAccessor.HttpContext.User.GetUserName();
            return await _unitOfWork.UserRepository
                .GetMemberAsync(username, isCurrentUser: currentUsername == username);
        }

        public async Task<PagedList<MemberDto>> GetUsers(UserParams userParams)
        {
            var gender = await _unitOfWork.UserRepository.GetUserGender(_httpContextAccessor.HttpContext.User.GetUserName());
            userParams.CurrentUsername = _httpContextAccessor.HttpContext.User.GetUserName();
            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = gender == "male" ? "female" : "male";
            }
            var users = await _unitOfWork.UserRepository.GetMembersAsync(userParams);
            _httpContextAccessor.HttpContext.Response.AddPaginationHeader(users.CurrentPage, users.PageSize,
                users.TotalCount, users.TotalPages);
            return users;
        }

        public async Task SetMainPhoto(int photoId)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(_httpContextAccessor.HttpContext.User.GetUserName());
            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);
            if (photo.IsMain)
            {
                _logger.LogInformation("This is already your main photo", photo.Url);
            }
            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;
            if (await _unitOfWork.Complete())
            {
                _logger.LogInformation("Photo Added {photo}", photo.Url);
            }
            else
            {
                _logger.LogError("Failed to set main photo {photo}", photo.Url);
            }
        }

        public async Task UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(_httpContextAccessor.HttpContext.User.GetUserName());
            _mapper.Map(memberUpdateDto, user);
            _unitOfWork.UserRepository.Update(user);
            if (await _unitOfWork.Complete())
            {
                _logger.LogInformation("User updated");
            }
            else
            {
                _logger.LogError("Failed to update user");
            }
        }
    }
}
