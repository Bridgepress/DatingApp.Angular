using API.DTOs;
using DatingApp.CommandAndQuery.Queries;

namespace DatingApp.CommandAndQuery.Users.GetUser
{
	public class GetUserQuery : IQuery<MemberDto>
	{
		public string Username { get; }

		public GetUserQuery(string username)
		{
			Username = username;
		}
	}
}
