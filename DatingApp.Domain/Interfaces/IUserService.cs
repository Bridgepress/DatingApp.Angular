using API.DTOs;
using API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
