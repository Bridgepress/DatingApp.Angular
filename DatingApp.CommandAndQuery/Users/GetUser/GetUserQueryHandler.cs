using API.DTOs;
using DatingApp.CommandAndQuery.Queries;
using DatingApp.Domain.Interfaces;
using MediatR;

namespace DatingApp.CommandAndQuery.Users.GetUser
{
	public class GetUserQueryHandler : IQueryHandler<GetUserQuery, MemberDto>
	{
		private readonly IMediator _mediator;
		private readonly IUserService _userService;

		public GetUserQueryHandler(IMediator mediator, IUserService userService)
		{
			_userService = userService;
			_mediator = mediator;
		}

		public async Task<MemberDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
		{
			return await _userService.GetUser(request.Username);
		}
	}
}
