using DatingApp.CommandAndQuery.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Likes.AddLike
{
    public class AddLikeCommand : BaseCommand
    {
        public string Username { get; set; }

        public AddLikeCommand(string username)
        {
            Username = username;
        }
    }
}
