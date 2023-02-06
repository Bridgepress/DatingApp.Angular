using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.CommandAndQuery.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
