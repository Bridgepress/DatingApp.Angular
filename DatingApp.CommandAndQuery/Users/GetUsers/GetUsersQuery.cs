using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Queries;

namespace DatingApp.CommandAndQuery.Users.GetUsers
{
	public class GetUsersQuery : IQuery<PagedList<MemberDto>>
	{
		public UserParams UserParams { get; }

		public GetUsersQuery(UserParams userParams)
		{
			UserParams = userParams;
		}
	}
}
