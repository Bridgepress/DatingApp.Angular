using API.DTOs;
using DatingApp.CommandAndQuery.Commands;

namespace DatingApp.CommandAndQuery.Users.UpdateUser
{
	public class UpdateUserCommand : BaseCommand
	{
		public MemberUpdateDto MemberUpdateDto { get; }

		public UpdateUserCommand(MemberUpdateDto memberUpdateDto)
		{
			MemberUpdateDto = memberUpdateDto;
		}
	}
}
