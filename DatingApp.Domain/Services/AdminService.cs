using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using DatingApp.Contracts.Repositories;
using DatingApp.Domain.Interfaces;
using DatingApp.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.Domain.Services
{
    public class AdminService : IAdminService
    {
        public readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private IMapper _mapper;
        private readonly ILogger<AdminService> _logger;

        public AdminService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,
           IPhotoService photoService, IMapper mapper, ILogger<AdminService> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _photoService = photoService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PhotoDto> ApprovePhoto(int photoId)
        {
            var photo = await _unitOfWork.PhotoRepository.GetPhotoById(photoId);
            if (photo == null)
            {
                _logger.LogError("Photo not found", typeof(PhotoDto));
                return null;
            }
            photo.IsApproved = true;
            var user = await _unitOfWork.UserRepository.GetUserByPhotoId(photoId);
            if (!user.Photos.Any(x => x.IsMain))
            {
                photo.IsMain = true;
            }
            await _unitOfWork.Complete();
            _logger.LogInformation("Photo Added {photo}", photo.Url);
            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task<IList<string>> EditRoles(string username, string roles)
        {
            if (string.IsNullOrEmpty(roles))
            {
                _logger.LogError("Roles is empty");
                return null;
            }
            var selectedRoles = roles.Split(",").ToArray();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                _logger.LogError("User not found {user}", user.UserName);
                return null;
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));
            if (!result.Succeeded)
            {
                _logger.LogError("Roles not added");
                return null;
            }
            result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));
            if (!result.Succeeded)
            {
                return null;
            }
            _logger.LogInformation("Roles Added");
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IEnumerable<PhotoForApprovalDto>> GetPhotosForModeration()
        {
            var photos = await _unitOfWork.PhotoRepository.GetUnapprovedPhotos();
            return _mapper.Map<IEnumerable<PhotoForApprovalDto>>(photos);
        }

        public async Task<List<UsersWithRolesDTO>> GetUsersWithRoles()
        {
            List<UsersWithRolesDTO> users = await _userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new UsersWithRolesDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();
            return users;
        }

        public async Task<PhotoDto> RejectPhoto(int photoId)
        {
            var photo = await _unitOfWork.PhotoRepository.GetPhotoById(photoId);
            if (photo.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Result == "ok")
                {
                    _unitOfWork.PhotoRepository.RemovePhoto(photo);
                }
            }
            else
            {
                _unitOfWork.PhotoRepository.RemovePhoto(photo);
            }
            await _unitOfWork.Complete();
            return _mapper.Map<PhotoDto>(photo);
        }
    }
}
