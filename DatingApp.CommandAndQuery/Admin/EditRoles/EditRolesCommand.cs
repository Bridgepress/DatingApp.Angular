using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Admin.EditRoles
{
    public class EditRolesCommand : BaseCommand<IList<string>>
    {
        public string Username { get; }
        public string Roles { get; }

        public EditRolesCommand(string username, string roles)
        {
            Username = username;
            Roles = roles;
        }
    }
}
