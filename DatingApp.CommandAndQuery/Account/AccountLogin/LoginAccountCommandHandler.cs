using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;

namespace DatingApp.CommandAndQuery.Account.AccountLogin
{
    public class LoginAccountCommandHandler : ICommandHandler<LoginAccountCommand, UserDto>
    {
        private readonly IMediator _mediator;
        private readonly IAccountService _accountService;

        public LoginAccountCommandHandler(IMediator mediator, IAccountService accountService)
        {
            _accountService = accountService;
            _mediator = mediator;
        }

        public async Task<UserDto> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new LoginDto { UserName = request.UserName, Password = request.Password };
            return await _accountService.Login(user);
        }
    }
}
