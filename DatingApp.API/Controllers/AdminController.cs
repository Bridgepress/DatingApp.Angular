using DatingApp.CommandAndQuery.Admin.ApprovePhoto;
using DatingApp.CommandAndQuery.Admin.EditRoles;
using DatingApp.CommandAndQuery.Admin.GetPhotosForModeration;
using DatingApp.CommandAndQuery.Admin.GetUsersWithRoles;
using DatingApp.CommandAndQuery.Admin.RejectPhoto;
using DatingApp.Domain.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class AdminController : BaseApiController
	{
		private readonly IMediator _mediator;

		public AdminController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[Authorize(Policy = MyPolicies.ModeratePhotoRole)]
		[HttpGet("photos-to-moderate")]
		public async Task<ActionResult> GetPhotosForModeration()
		{
			var photos = await _mediator.Send(new GetPhotosForModerationQuery());
			return Ok(photos);
		}

		[Authorize(Policy = MyPolicies.ModeratePhotoRole)]
		[HttpPost("approve-photo/{photoId}")]
		public async Task<ActionResult> ApprovePhoto(int photoId)
		{
			var photo = await _mediator.Send(new ApprovePhotoCommand(photoId));
			return Ok();
		}

		[Authorize(Policy = MyPolicies.RequireAdminRole)]
		[HttpPost("reject-photo/{photoId}")]
		public async Task<ActionResult> RejectPhoto(int photoId)
		{
			var photo = await _mediator.Send(new RejectPhotoCommand(photoId));
			return Ok();
		}

		[Authorize(Policy = MyPolicies.RequireAdminRole)]
		[HttpGet("users-with-roles")]
		public async Task<ActionResult> GetUsersWithRoles()
		{
			var users = await _mediator.Send(new GetUsersWithRolesQuery());
			return Ok(users);
		}

		[Authorize(Policy = MyPolicies.RequireAdminRole)]
		[HttpPost("edit-roles/{username}")]
		public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
		{
			return Ok(await _mediator.Send(new EditRolesCommand(username, roles)));
		}
	}
}
