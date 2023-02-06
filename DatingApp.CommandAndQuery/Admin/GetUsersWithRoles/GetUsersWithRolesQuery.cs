using DatingApp.CommandAndQuery.Queries;
using DatingApp.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.GetUsersWithRoles
{
    public class GetUsersWithRolesQuery : IQuery<List<UsersWithRolesDTO>>
    {
        public GetUsersWithRolesQuery()
        {
        }
    }
}
