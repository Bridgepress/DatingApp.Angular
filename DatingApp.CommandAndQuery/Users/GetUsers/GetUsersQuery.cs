using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
