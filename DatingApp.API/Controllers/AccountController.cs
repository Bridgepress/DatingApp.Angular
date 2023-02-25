using API.DTOs;
using DatingApp.CommandAndQuery.Account.AccountCreate;
using DatingApp.CommandAndQuery.Account.AccountLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	public class AccountController : BaseApiController
	{
		private readonly IMediator _mediator;

		public AccountController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("register")]
		public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
		{
			var user = await _mediator.Send(new RegisterAccountCommand(registerDto.UserName, registerDto.KnowAs, registerDto.Gender,
				registerDto.DateOfBirth, registerDto.City, registerDto.Country, registerDto.Password));
			if (user == null)
			{
				return Unauthorized();
			}
			return Created(string.Empty, user);
		}

		[HttpPost("login")]
		public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
		{
			var user = await _mediator.Send(new LoginAccountCommand(loginDto.UserName, loginDto.Password));
			return user;
		}
	}
}
