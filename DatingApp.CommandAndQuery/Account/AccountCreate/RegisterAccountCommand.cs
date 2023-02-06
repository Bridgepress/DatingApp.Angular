using API.DTOs;
using DatingApp.CommandAndQuery.Commands;

namespace DatingApp.CommandAndQuery.Account.AccountCreate
{
    public class RegisterAccountCommand : BaseCommand<UserDto>
    {
        public string UserName { get; }
        public string KnowAs { get; }
        public string Gender { get; }
        public DateTime? DateOfBirth { get; }
        public string City { get; }
        public string Country { get; }
        public string Password { get; }

        public RegisterAccountCommand(string userName, string knowAs, string gender, DateTime? dateOfBirth, string city, string country, string password)
        {
            UserName = userName;
            KnowAs = knowAs;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            City = city;
            Country = country;
            Password = password;
        }
    }
}
