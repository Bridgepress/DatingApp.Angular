using DatingApp.CommandAndQuery.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Messages.DeleteMessage
{
    public class DeleteMessageCommand : BaseCommand
    {
        public int Id { get; }

        public DeleteMessageCommand(int id)
        {
            Id = id;
        }
    }
}
