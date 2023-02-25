using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;

namespace DatingApp.CommandAndQuery.Users.SetMainPhoto
{
	public class SetMainPhotoCommandHandler : ICommandHandler<SetMainPhotoCommand>
	{
		private readonly IMediator _mediator;
		private readonly IUserService _userService;

		public SetMainPhotoCommandHandler(IMediator mediator, IUserService userService)
		{
			_userService = userService;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(SetMainPhotoCommand request, CancellationToken cancellationToken)
		{
			await _userService.SetMainPhoto(request.PhotoId);
			return Unit.Value;
		}
	}
}
