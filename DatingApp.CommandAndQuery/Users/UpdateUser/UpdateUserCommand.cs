using API.DTOs;
using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
