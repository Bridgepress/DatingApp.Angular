using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;

namespace DatingApp.CommandAndQuery.Users.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IMediator mediator, IUserService userService)
        {
            _userService = userService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.UpdateUser(request.MemberUpdateDto);
            return  Unit.Value;
        }
    }
}
