using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Commands;
using DatingApp.CommandAndQuery.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Messages.GetMessagesForUser
{
    public class GetMessagesForUserQuery : IQuery<PagedList<MessageDto>>
    {
        public MessageParams MessageParams { get; }

        public GetMessagesForUserQuery(MessageParams messageParams)
        {
            MessageParams = messageParams;
        }
    }
}
