using API.DTOs;
using DatingApp.CommandAndQuery.Commands;

namespace DatingApp.CommandAndQuery.Account.AccountLogin
{
    public class LoginAccountCommand : BaseCommand<UserDto>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginAccountCommand(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
