using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;

namespace DatingApp.CommandAndQuery.Account.AccountCreate
{
    public class RegisterAccountCommandHandler : ICommandHandler<RegisterAccountCommand, UserDto>
    {
        private readonly IAccountService _accountService;

        public RegisterAccountCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<UserDto> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new RegisterDto
            {
                UserName = request.UserName,
                Password = request.Password,
                City = request.City,
                Country = request.Country,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                KnowAs = request.KnowAs
            };
            return await _accountService.Register(user);
        }
    }
}
