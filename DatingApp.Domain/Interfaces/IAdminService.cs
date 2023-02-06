using API.DTOs;
using DatingApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Domain.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<PhotoForApprovalDto>> GetPhotosForModeration();
        Task<PhotoDto> ApprovePhoto(int photoId);
        Task<PhotoDto> RejectPhoto(int photoId);
        Task<List<UsersWithRolesDTO>> GetUsersWithRoles();
        Task<IList<string>> EditRoles(string username, string roles);
    }
}
