using API.DTOs;
using API.Helpers;
using DatingApp.CommandAndQuery.Queries;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Messages.GetMessagesForUser
{
    public class GetMessagesForUserQueryHandler : IQueryHandler<GetMessagesForUserQuery, PagedList<MessageDto>>
    {
        private readonly IMediator _mediator;
        private readonly IMessagesService _messagesService;

        public GetMessagesForUserQueryHandler(IMediator mediator, IMessagesService messagesService)
        {
            _messagesService = messagesService; 
            _mediator = mediator;
        }

        public async Task<PagedList<MessageDto>> Handle(GetMessagesForUserQuery request, CancellationToken cancellationToken)
        {
            return await _messagesService.GetMessagesForUser(request.MessageParams);
        }
    }
}
