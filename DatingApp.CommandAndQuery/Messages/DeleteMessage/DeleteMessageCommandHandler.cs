using DatingApp.CommandAndQuery.Commands;
using DatingApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.CommandAndQuery.Messages.DeleteMessage
{
    internal class DeleteMessageCommandHandler : ICommandHandler<DeleteMessageCommand>
    {
        private readonly IMediator _mediator;
        private readonly IMessagesService _messagesService;

        public DeleteMessageCommandHandler(IMediator mediator, IMessagesService messagesService)
        {
            _messagesService = messagesService;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            await _messagesService.DeleteMessage(request.Id);
            return Unit.Value;
        }
    }
}
