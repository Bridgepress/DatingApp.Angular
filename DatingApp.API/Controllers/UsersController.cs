using API.DTOs;
using API.Extensions;
using API.Helpers;
using DatingApp.CommandAndQuery.Users.AddPhoto;
using DatingApp.CommandAndQuery.Users.DeletePhoto;
using DatingApp.CommandAndQuery.Users.GetUser;
using DatingApp.CommandAndQuery.Users.GetUsers;
using DatingApp.CommandAndQuery.Users.SetMainPhoto;
using DatingApp.CommandAndQuery.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[AllowAnonymous]
	public class UsersController : BaseApiController
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet(Name = "GetUsers")]
		public async Task<ActionResult<PagedList<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
		{
			var users = await _mediator.Send(new GetUsersQuery(userParams));
			return Ok(users);
		}

		[HttpGet("{username}", Name = "GetUser")]
		public async Task<ActionResult<MemberDto>> GetUser(string username)
		{

			return await _mediator.Send(new GetUserQuery(username));
		}

		[HttpPut]
		public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
		{
			await _mediator.Send(new UpdateUserCommand(memberUpdateDto));
			return Ok();
		}

		[HttpPost("add-photo")]
		public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
		{
			var photo = await _mediator.Send(new AddPhotoCommand(file));
			return CreatedAtRoute("GetUser", routeValues: new { username = User.GetUserName() }, photo);

		}

		[HttpPut("set-main-photo/{photoId}")]
		public async Task<ActionResult> SetMainPhoto(int photoId)
		{
			await _mediator.Send(new SetMainPhotoCommand(photoId));
			return Ok();
		}

		[HttpDelete("delete-photo/{photoId}")]
		public async Task<ActionResult> DeletePhoto(int photoId)
		{
			await _mediator.Send(new DeletePhotoCommand(photoId));
			return Ok();
		}
	}
}
