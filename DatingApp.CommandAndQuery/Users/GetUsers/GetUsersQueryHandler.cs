using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Queries;
using DatingApp.Domain.Interfaces;
using MediatR;

namespace DatingApp.CommandAndQuery.Users.GetUsers
{
	internal class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, PagedList<MemberDto>>
	{
		private readonly IMediator _mediator;
		private readonly IUserService _userService;

		public GetUsersQueryHandler(IMediator mediator, IUserService userService)
		{
			_userService = userService;
			_mediator = mediator;
		}

		public async Task<PagedList<MemberDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
		{
			return await _userService.GetUsers(request.UserParams);
		}
	}
}
