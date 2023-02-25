using API.DTOs;
using DatingApp.Shared.DTOs;

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
