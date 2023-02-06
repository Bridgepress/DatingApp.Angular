using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using DatingApp.Domain.Exceptions.InfrastructureExceptions;
using DatingApp.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace DatingApp.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountService> _logger;

        public AccountService(UserManager<AppUser> userManager, ITokenService tokenService,
            IMapper mapper, ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                 .Include(x => x.Photos)
                 .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (user == null)
            {
                _logger.LogError("User not found {Type}", typeof(LoginDto));
                return null;
            }
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                _logger.LogError("Invalid password {Type}", typeof(LoginDto));
                return null;
            }
            _logger.LogInformation("Successfully login {User}", user.UserName);
            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnowAs = user.KnowAs,
                Gender = user.Gender
            };
        }

        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName))
            {
                _logger.LogError("User not found {Type}", typeof(RegisterDto));
                return null;
            }
            var user = _mapper.Map<AppUser>(registerDto);
            user.UserName = registerDto.UserName.ToLower();
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                _logger.LogError("Invalid password: {Type}", result.Errors.ToString());
                return null;
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded)
            {
                _logger.LogError("Add Rols error: {Type}", result.Errors.ToString());
                return null;
            }
            _logger.LogInformation("Successfully Registration {User}", user.UserName);
            return new UserDto
            {
                UserName = user.UserName,
                Token = await _tokenService.CreateToken(user),
                KnowAs = user.KnowAs,
                Gender = user.Gender
            };
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == userName.ToLower());
        }
    }
}
